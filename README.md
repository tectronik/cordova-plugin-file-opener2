A File Opener Plugin for Cordova (fork of the original version)
==========================
This plugin will open a file on your device file system with its default application.

Original File Opener Plugin
-------------
[https://github.com/pwlin/cordova-plugin-file-opener2](https://github.com/pwlin/cordova-plugin-file-opener2)

Requirements
-------------
- Android 4 or higher / iOS 6 or higher / WP8
- Cordova 3.0 or higher

Installation
-------------
    cordova plugin add https://github.com/tectronik/cordova-plugin-file-opener2-tectronik
    
PhoneGap Build
---------------
This plugin is also avaible via [npm](https://www.npmjs.com/package/cordova-plugin-file-opener2-tectronik) and it can be found with [Cordova Plugin Search](http://plugins.cordova.io/npm/index.html).
Add to your `config.xml`:

    <gap:plugin name="cordova-plugin-file-opener2-tectronik" source="npm" />

Usage
------
Open an APK install dialog:

    cordova.plugins.fileOpener2.open(
        '/sdcard/Download/gmail.apk', 
        'application/vnd.android.package-archive'
    );
    
Open a PDF document with the default PDF reader and optional callback object:

    cordova.plugins.fileOpener2.open(
        '/sdcard/Download/starwars.pdf',
        'application/pdf', 
        { 
            error : function(e) { 
                console.log('Error status: ' + e.status + ' - Error message: ' + e.message);
            },
            success : function () {
                console.log('file opened successfully'); 				
            }
        }
    );

Notes
------

- For properly opening a PDF file, you must already have a PDF reader (Acrobat Reader, Foxit Mobile PDF, etc. ) installed on your mobile device. Otherwise this will not work

- [It is reported](https://github.com/pwlin/cordova-plugin-file-opener2/issues/2#issuecomment-41295793) that in iOS, you might need to remove `<preference name="iosPersistentFileLocation" value="Library" />` from your `config.xml`


Additional Android Functions
-----------------------------
####The following functions are available in Android platform

###.uninstall(_packageId, callbackContext_)
Uninstall a package with its id.

    cordova.plugins.fileOpener2.uninstall('com.zynga.FarmVille2CountryEscape', {
        error : function(e) {
            console.log('Error status: ' + e.status + ' - Error message: ' + e.message);    
        },
        success : function() {
            console.log('Uninstall intent activity started.');
        }
    });

###.appIsInstalled(_packageId, callbackContext_)
Check if an app is already installed.

    cordova.plugins.fileOpener2.appIsInstalled('com.adobe.reader', {
        success : function(res) {
            if (res.status === 0) {
                console.log('Adobe Reader is not installed.');
            } else {
                console.log('Adobe Reader is installed.')
            }
        }
    });

Contributors
------------
[@Gillardo:](https://github.com/Gillardo/) Support for WP8

LICENSE
--------
The MIT License (MIT)

Copyright (c) 2015 Martin Langasek (fork)

Copyright (c) 2013 pwlin - pwlin05@gmail.com (original version)

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
