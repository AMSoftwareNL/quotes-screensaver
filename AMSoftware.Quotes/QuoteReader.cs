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
using System.IO;
using System.Xml.Serialization;

namespace AMSoftware.Quotes
{
    internal abstract class QuoteReader : IDisposable
    {
        protected Quotes _quotes = null;

        public static QuoteReader Create(string inputUri)
        {
            string extension = Path.GetExtension(inputUri);
            if (extension.Equals(".xml", StringComparison.InvariantCultureIgnoreCase))
            {
                return new XmlQuoteReader(inputUri);
            }
            else
            {
                throw new ArgumentException("Only XML is supported.");
            }
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

        public virtual Quote Read()
        {
            if (_quotes == null || _quotes.Count == 0)
            {
                return QuoteReader.Default;
            }

            Random r = new Random();
            return _quotes[r.Next(0, _quotes.Count - 1)];
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

    internal class XmlQuoteReader : QuoteReader
    {
        public XmlQuoteReader(string inputUri)
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
    }
}
