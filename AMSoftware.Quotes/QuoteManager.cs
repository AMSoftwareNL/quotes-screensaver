/*
Quotes Screensaver
Copyright (C) 2018 Arjan Meskers / AMSoftware

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published
by the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;


namespace AMSoftware.Quotes
{
    internal abstract class QuoteManager : IDisposable, IEnumerable<Quote>
    {
        protected Quotes _quotes = null;
        protected string _inputFileName = null;

        public static QuoteManager Create(string inputUri)
        {
            string extension = Path.GetExtension(inputUri);
            if (extension.Equals(".xml", StringComparison.InvariantCultureIgnoreCase))
            {
                return new XmlQuoteManager(inputUri);
            }
            else if (extension.Equals(".json", StringComparison.InvariantCultureIgnoreCase))
            {
                return new JsonQuoteManager(inputUri);
            }
            else
            {
                throw new ArgumentException("Only XML or JSON are supported.");
            }
        }

        public QuoteManager(string inputUri)
        {
            _inputFileName = inputUri;
        }

        public static Quote Default
        {
            get
            {
                return new Quote()
                {
                    QuoteText = new string[] {
                            "Lorem ipsum dolor sit amet,",
                            "onsectetuer adipiscing elit."
                        },
                    Author = "Lorem Ipsum",
                    Year = DateTime.Today.Year.ToString()
                };
            }
        }

        public virtual void Close()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual Quote ReadRandom()
        {
            if (_quotes == null || _quotes.Count == 0)
            {
                return QuoteManager.Default;
            }

            Random r = new Random();
            return _quotes[r.Next(0, _quotes.Count - 1)];
        }

        public abstract void WriteToFile(Quotes quotes);

        public IEnumerator<Quote> GetEnumerator()
        {
            return ((IEnumerable<Quote>)_quotes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Quote>)_quotes).GetEnumerator();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }

    internal class XmlQuoteManager : QuoteManager
    {
        public XmlQuoteManager(string inputUri) : base(inputUri)
        {
            if (string.IsNullOrWhiteSpace(inputUri))
            {
                throw new ArgumentNullException("inputUri");
            }

            using (Stream inputStream = File.OpenRead(inputUri))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Quotes));
                _quotes = serializer.Deserialize(inputStream) as Quotes;
            }
        }

        public override void WriteToFile(Quotes quotes)
        {
            using (Stream outputStream = File.Create(_inputFileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Quotes));
                serializer.Serialize(outputStream, quotes);
            }
        }
    }

    internal class JsonQuoteManager : QuoteManager
    {
        public JsonQuoteManager(string inputUri) : base(inputUri)
        {
            if (string.IsNullOrWhiteSpace(inputUri))
            {
                throw new ArgumentNullException("inputUri");
            }

            using (Stream inputStream = File.OpenRead(inputUri))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Quotes));
                _quotes = serializer.ReadObject(inputStream) as Quotes;
            }
        }

        public override void WriteToFile(Quotes quotes)
        {
            using (Stream outputStream = File.Create(_inputFileName))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Quotes));
                serializer.WriteObject(outputStream, quotes);
            }
        }
    }
}
