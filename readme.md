# Cyotek Azure Container Echo

## About
The Azure Container Echo is a small utility program that sits in your system tray. At predefined intervals, it will scan any Azure blob containers you have configured, and download missing or changed files. Nothing more, nothing less.

This program was written in a hurry to fill a specific need, and there's plenty of room of improvement. But at the same time, it does the job it is asked to do and seems to do it well!

## Example Screenshots

![Running normally](http://static.cyotek.com/files/articleimages/azuredownload-1d.png "An example of the application doing its thing")

The application sits in your system tray, and periodically sans the storage accounts to download.

![Main settings window](http://static.cyotek.com/files/articleimages/azuredownload-1b.pn)

This is the main settings window. Not much to see, you can specify if you want the program to start with Windows, and define the containers you wish to monitor.

![Account properties window](http://static.cyotek.com/files/articleimages/azuredownload-1a.pn)

For each account, you define the name, the access key, the container to monitor and the path where local path files will be downloaded. You can also optionally have missing / changed local files uploaded into the container.

Finally, you can specify how often you wish the container to be checked.

![Error tooltip](http://static.cyotek.com/files/articleimages/azuredownload-1c.png "An example of a failed task")

Error handling is rudimentary at best, logging support is not available at present, all you get is a balloon tooltip.

## License

The Azure Container Echo project is licensed under the MIT License. See `license.txt` for the full text. 

## Further Reading

For more information, see article [tagged with Azure](http://cyotek.com/blog/tag/azure) at cyotek.com.
