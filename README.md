# Cyotek Azure Container Echo

## About
Cyotek Azure Container Echo is a small utility program that sits in your system tray. At predefined intervals, it will scan any Azure blob containers you have configured, and download missing or changed files. A smattering of additional options exist, such as deleting the remote blob after download, or even uploading local files.

This program was written in a hurry to fill a specific need, and there's plenty of room of improvement - additional options and resilience will be added over time, contributions are welcome!

## Example Screenshots

![Running normally](http://static.cyotek.com/files/articleimages/azuredownload-1d.png "An example of the application doing its thing")

The application sits in your system tray, and periodically sans the storage accounts to download.

![Main settings window](http://static.cyotek.com/files/productimages/azurecontainerecho/settings.png)

This is the main settings window. Not much to see, you can specify if you want the program to start with Windows, and define the containers you wish to monitor.

![Account properties window](http://static.cyotek.com/files/productimages/azurecontainerecho/jobprops.png)

For each account, you define the name, the access key, the container to monitor and the path where local path files will be downloaded. You can also optionally have missing / changed local files uploaded into the container, or delete remote files after they have been successfully downloaded.

Finally, you can specify if the job should actually run, and how often you wish the container to be checked.

![Error tooltip](http://static.cyotek.com/files/articleimages/azuredownload-1c.png "An example of a failed task")

Error handling is rudimentary at best, logging support is not available at present, all you get is a balloon tooltip.

## License

The Azure Container Echo project is licensed under the MIT License. See `license.txt` for the full text. 

## Further Reading

For more information, see article [tagged with Azure](http://cyotek.com/blog/tag/azure) at cyotek.com.
