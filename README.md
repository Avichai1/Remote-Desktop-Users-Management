# Terminal-Severs-Remote-Desktop-Users-Managemnent
Options: Monitoring all users of your Terminal Servers. There are options to remote session and logoff sessions with connected and disconnected stats


If the feature "Remote Control" is not working, please change your GPO:



1) Open Group Policy Editor (Gpedit.msc) on the server that is running Terminal Services or in you DC Server open Group Policy Management (gpmc.msc)
2)Under Computer Configuration, expand Administrative Templates, expand Windows Components, expand Remote Desktop Services,
expand Remote Session Host, and then click on connections.
3)Right-click Sets rules for remote control of Remote Desktop user sessions, and then click Edit.
4)Select Enabled.
5)To remote control the console with no prompt for approval:     Under Options, select Full Control without user's permission.
  To remote control the console with no prompt for approval:     Under Options, select Full Control with user's permission.
 

Click OK, and then quit Group Policy Editor.

For updating the policies open command prompt and write: gpupdate /force or restart the servers 