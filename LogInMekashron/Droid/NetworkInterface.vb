Imports System.Net.NetworkInformation.NetworkInterface
Imports System.Net

Public Interface NetworkInterface
    Function Ping(IP As String)
    Event PingEvent(IP As String)
    Function Tracert(IP As String)
    Event TracertEvent(IP As String)
End Interface
