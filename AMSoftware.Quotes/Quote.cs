/*
Quotes Screensaver
Copyright (C) 2020 Arjan Meskers / AMSoftware

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
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AMSoftware.QuotesScreensaver
{
    [Serializable]
    [DataContract]
    public class Quote
    {
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string Year { get; set; }
        [DataMember]
        public string Source { get; set; }
        [DataMember]
        public string[] QuoteText { get; set; }
    }

    [Serializable]
    [CollectionDataContract]
    public class Quotes : List<Quote>
    {

    }
}
