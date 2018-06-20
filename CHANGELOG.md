# Change Log

## 1.4.1
### Added
* Added the ability to duplicate jobs

## 1.4.0
### Changed
* Switched to semantic versioning
* Job list now colour codes items

## 1.0.3.0
* Added an **Open Log** option to the tray icon context menu
* After downloading, the hash of the remote blob and local file are compared and the job will now fail if they don't match
* Added a new **Delete remote file after downloading** option to allow remote blobs to be deleted after copying locally
* Fixed typo in the spelling of the successful 

## 1.0.2.0
* Added a new Enabled property to jobs to allow them to be temporarily disabled without removing them
* When the **Check for new or missing files only** option is set, only remote blobs modified since the last time the job was executed will be downloaded
* Fixed an issue where changing the **Interval** property of a job didn't persist unless another value was changed at the same time
* Moved container validation out of the client program to avoid it having multiple references that it doesn't need

## 1.0.1.0
* Updated Windows Azure Storage component to 3.0
* Updated Json.NET component to 6.0
* Updated Windows Azure Configuration Manager component
* Added a new option to only check for missing files, not to look for changes
* Added a new "Run Now" option to the context menu
* Added basic logging

## 1.0.0.1
* Updated Windows Azure Storage component to 2.1

## 1.0.0.0
* Initial release

