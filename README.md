# Cyotek Azure Container Echo

Cyotek Azure Container Echo is a small utility program that sits
in your system tray. At predefined intervals, it will scan any
Azure blob containers you have configured, and download missing
or changed files. A smattering of additional options exist, such
as deleting the remote blob after download, or even uploading
local files.

This program was written in a hurry to fill a specific need, and
there's plenty of room of improvement - additional options and
resilience will be added over time, contributions are welcome!

## Example Screenshots

![Running normally][trayicon]

The application sits in your system tray, and periodically sans
the storage accounts to download.

![Main settings window][accounts]

![General settings][settings]

![Viewing the end of the log][logtail]

The **Accounts** tab allows you to define the echo jobs.
**Settings** allows you to configure if the application starts
with Windows and if timestamps are logged in local or UTC.
Finally, **Log Tail** provides quick access to the end of the
log.

![Account properties window][jobproperties]

For each account, you define the name, the access key, the
container to monitor and the path where local path files will be
downloaded. You can also optionally have missing / changed local
files uploaded into the container, or delete remote files after
they have been successfully downloaded.

Finally, you can specify if the job should actually run, and how
often you wish the container to be checked.

![Error tooltip][failedjob]

Error handling is rudimentary at best, logging support is not
available at present, all you get is a balloon tooltip.

## License

The Azure Container Echo project is licensed under the MIT
License. See `LICENSE.txt` for the full text.

## Further Reading

For more information, see article [tagged with Azure][blog] at
cyotek.com.

[trayicon]: res/trayicon.png
[accounts]: res/settings.png
[settings]: res/settings-general.png
[logtail]: res/settings-log.png
[jobproperties]: res/jobprops.png
[failedjob]: res/trayicon-error.png
[blog]: https://devblog.cyotek.com/tag/azure
