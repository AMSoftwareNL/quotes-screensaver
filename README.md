## AMSoftware Quotes Screensaver

**Project Description**

Screensaver for Windows displaying (random) quotes from a file.

**Quotes file**
The file containing quotes is an XML-file containing a serialized list of Quote objects.

This XML must have the following structure:

````
<?xml version="1.0" encoding="utf-8"?>
<ArrayOfQuote 
  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
  xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Quote>
    <Author>John Crichton (Farscape)</Author>
    <QuoteText>
      <string>Look upward, and share...</string>
      <string>the wonders I have seen.</string>
    </QuoteText>
  </Quote>
</ArrayOfQuote>
````

**Use the screensaver**
A screensaver in Windows is nothing more than an executable (EXE) renamed to the extension 'SCR'. 

Place the SCR-file in %SYSTEMROOT%\System32 (c:\windows\system32\) and it will be available in the settings. The ``quotes.xml`` can be located anywhere. The location can be set using the screensaver settings.

