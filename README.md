X.DynamicData
=============

Modern Dynamic Data Project (based on ASP.NET Dynamic Data)

#Initial configuration of the system

To configure the file system, you must specify a value web.cofig such fields as:
- title - the title of the project
- website-url address web application
- application-storage-connection-string - the connection string to the repository that contains the Web application
- storage-url - root url store downloaded files
- storage-connection-string - the connection string to the repository which contains the downloaded files
- scaffold-all-tables - scaffold all table, or not
- show-logs-in-menu - show or hide Logs in menu
- logo - application logo
- data-context-assembly-location - path to the assembly containing the model classes. (Generation time EntityFrameowrk)

It is also necessary to add to the configuration file connection string to the database from the main web application.


#Download files

Data management system  and managed web-based application can be located on different hosts. Now we support three versions of interaction with the file storage web application:

* The file system
* FTP

###The control system and web application are on the same server
In this case, the parameters WebsiteUrl, WebsiteStorageConnectionString, StorageUrl and StorageConnectionString need to write the path to the appropriate directories web application.

###The control system and web application servers are on different server (via FTP)
In this case, the WebsiteStorageConnectionString and StorageConnectionString filled strokjy connect to the FTP type:
ftp://user:password @ example.com / wwwroot / site /
and ftp://user:password @ example.com / wwwroot / site / static


# Changes from the original version of Dynamic Data
- Added support for Entity Framework 6.0
- Redesigned visual interface (based on the Twitter Bootstrap, added compatibility with mobile devices)
- Added functionality upload files to the web application
- Added editors such fields as html-editor (CKEditor), map (Google Map), calendar, and other
- Fixed incorrect work of many to many relationship
- Added the ability to view information about the server configuration
- Added the ability to login to the system
- Added globaization (English and Russian localization at the moment)
- And more

For more details about the system can be found in the publication: http://habrahabr.ru/post/181804/ (russian)
