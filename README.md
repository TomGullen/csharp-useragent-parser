csharp-useragent-parser
=======================

C# User Agent Parser extracts OS/Browser etc from user agent string.

This is in no way complete or comprehensive, but please feel free to refine and update!


Usage
=======================

Simply:

var userAgentInfo = new UserAgentInfo(context.Request.UserAgent);

You can then retrieve the components of the user agent as follows:

var browser = userAgentInfo.Browser;

Casting the components to int returns a unique ID:

var browserID = (int)userAgentInfo.Browser;
