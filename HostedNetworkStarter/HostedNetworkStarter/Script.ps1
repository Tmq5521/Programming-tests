#
# Script.ps1
#

echo "Welcome to Wlan Hosted Network auto-starter.";
$ssid = read-host "Enter a SSID";
$key = read-host "Enter a Password (more than 8 charachters)";
netsh wlan set hostednetwork ssid=$ssid key=$key;
netsh wlan start hostednetwork;
while (1) {
    echo "";
    $string = read-host "Enter a command";
    echo "";
    switch($string) {
        "stop" { 
                        netsh wlan stop hostednetwork;
                        echo "Stopped.";
                        Exit
                        }
        "list" { 
                        netsh wlan show hostednetwork | format-list;
                        }
        "getpassword" {
                        netsh wlan show hostednetwork setting=security | format-list;
                        }
        "setpassword" {
                        $key = read-host "Enter a Password (more than 8 charachters)"
                        netsh wlan set hostednetwork key=$key;
                        netsh wlan refresh hostednetwork key;
                        }
        "setssid" {
                        $ssid = read-host "Enter a SSID"
                        netsh wlan set hostednetwork SSID=$ssid;
                        }
        "help" {
                        echo "Valid commands are:"; 
                        echo "";
                        echo "Stop - Stops the network and exits."; 
                        echo "List - Lists the network information.";
                        echo "GetPassword - Displays the pasword.";
                        echo "SetPassword - Sets the pasword."; 
                        echo "SetSSID - Sets the SSID.";
                        echo "Help - Shows help.";
                        echo "? - Shows help.";
                        }
        "?" {
                        echo "Valid commands are:"; 
                        echo "";
                        echo "Stop - Stops the network and exits."; 
                        echo "List - Lists the network information.";
                        echo "GetPassword - Displays the pasword.";
                        echo "SetPassword - Sets the pasword."; 
                        echo "SetSSID - Sets the SSID.";
                        echo "Help - Shows help.";
                        echo "? - Shows help.";
                        }
        default { 
                        echo "Invalid command.";
                        echo "Try ? for a list of commands";
                        }
                    }
}
        
