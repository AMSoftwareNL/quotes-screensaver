## AMSoftware Quotes Screensaver

**Project Description**

Screensaver for Windows displaying (random) quotes from a file.

**Quotes file**

The file containing quotes is an XML- or JSON-file containing a serialized list of Quote objects.

The XML must have the following structure:

````
<?xml version="1.0" encoding="utf-8"?>
<ArrayOfQuote 
  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
  xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Quote>
    <Author>John Crichton</Author>
    <Source>Farscape</Source>
    <Year>1999</Year>
    <QuoteText>
      <string>Look upward, and share...</string>
      <string>the wonders I have seen.</string>
    </QuoteText>
  </Quote>
</ArrayOfQuote>
````

The JSON must have the following structure:

````
[
  {
    "Author": "John Crichton",
    "Source": "Farscape",
    "Year": "1999",
    "QuoteText": [
      "Look upward, and share...",
      "the wonders I have seen."
    ]
  }
]
````

**Use the screensaver**

A screensaver in Windows is nothing more than an executable (EXE) renamed to the extension 'SCR'. 

Place the SCR-file in ``%SYSTEMROOT%\System32`` (``c:\windows\system32\``) and it will be available in the settings. The ``quotes.xml`` or ``quotes.json`` can be located anywhere. The location can be set using the screensaver settings.

**Features**

The screensaver has the following features:

* Browse for custom quotes file;
* Select preferred font and color;
* Set text alignment;
  * **Auto:** Align lines left and right for even and uneven lines. If text is wider than half a screen align with layout area, if text is less wide than half a screen, align width center screen;
  * **Left:** All lines are aligned left;
  * **Right:** All lines are aligned right;
  * **Center:** All lines are aligned center;
* Shrink to fit screen;
  Shrink font so every lines fits on to the screen. If not enabled lines will be word wrapped;
* Browse for custom background image;
* Set custom background color;
* Set image alignment;
  * **Fit:** Resize image to fit within screen-boundaries. Keeps aspect ratio, and doesn't clip image;
  * **Stretch:** Resize image to fit within screen-boundaries. Keeps aspect ratio, and does clip image;
  * **Center:** Centers the image without scaling, and clips image if needed;
  * **Tile:** Tiles the image without scaling, and clips image if needed;
* Opacity: Fades the background image using the background color;
* Preview from Settings;
* Quotes Editor from Settings;