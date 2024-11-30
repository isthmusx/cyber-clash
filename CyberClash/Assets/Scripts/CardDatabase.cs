using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "End-to-End Encryption", "Security", "Offense", 1, 60, "Deal 60 damage", Resources.Load<Sprite>("CardImages/Card 0"), 1, 0, 0,0,0,0, " ","No third party can see the messages between you and the other person"));
        cardList.Add(new Card(1, "Anti-Virus", "Security", "Offense", 1, 60, "Deal 60 damage", Resources.Load <Sprite> ("CardImages/Card 1"), 1,0 , 0,0,0,0, " ","Scan the device using antivirus to detect malware and remove it"));
        cardList.Add(new Card(2, "Authenticator", "Security", "Offense", 1, 70, "Deal 70 damage", Resources.Load<Sprite>("CardImages/Card 2"), 1, 0, 0,0,0,0, " ","Authenticator provides a layer of security to verify your identity when you logging into accounts"));
        cardList.Add(new Card(3, "Firewall", "Security", "Offense", 1, 70, "Deal 70 damage", Resources.Load<Sprite>("CardImages/Card 3"), 1, 0, 0,0,0,0, " ","Blocks unauthorized access in the computer system or network"));
        cardList.Add(new Card(4, "Ad blocker", "Security", "Offense", 1, 50, "Deal 50 damage", Resources.Load<Sprite>("CardImages/Card 4"), 1, 0, 0,0,0,0, " ","Ad blocker prevents pop-up advertisements to appear on web pages"));
        cardList.Add(new Card(5, "Strong Password","Security", "Offense", 2, 90, "Deal 90 damage", Resources.Load<Sprite>("CardImages/Card 5"), 0, 0, 0,0,0,0, " ","It is a combination of letters, number or even symbols"));
        cardList.Add(new Card(6, "OS Update", "Security", "Offense", 2, 100, "Deal 100 damage", Resources.Load<Sprite>("CardImages/Card 6"), 0, 0, 0,0,0,0, " ","Update operating system to fix vulnerabilities and improve security"));
        cardList.Add(new Card(7, "Data Encryption", "Security", "Offense", 2, 100, "Deal 100 damage", Resources.Load<Sprite>("CardImages/Card 7"), 0, 0, 0,0,0,0, " ","Process of converting information into a coded format"));
        cardList.Add(new Card(8, "Two-Factor Authentication", "Security", "Offense", 2, 80, "Deal 80 damage", Resources.Load<Sprite>("CardImages/Card 8"), 0, 0, 0,0,0, 0," ","Two form verification such as password or a code sent to your phone"));
        cardList.Add(new Card(9, "Multi-Factor Authentication", "Security", "Offense", 2, 90, "Deal 90 damage", Resources.Load<Sprite>("CardImages/Card 9"), 0, 0, 0,0,0,0, " ","Multiple form verification such as password, token and fingerprint"));
        cardList.Add(new Card(10, "OTP", "Security", "Offense", 3, 140, "Deal 140 damage", Resources.Load<Sprite>("CardImages/Card 10"), 0, 0, 0,0,0,0, " ","One Time Password is a single use of a code to access account"));
        cardList.Add(new Card(11, "Browser Update", "Security", "Offense", 3, 120, "Deal 120 damage", Resources.Load<Sprite>("CardImages/Card 11"), 0, 0, 0,0,0,0, " ","Update browser, it often include patches vulnerabilities in security"));
        cardList.Add(new Card(12, "Cloud Security", "Security", "Offense", 3, 120, "Deal 120 damage", Resources.Load<Sprite>("CardImages/Card 12"), 0, 0, 0,0,0,0, " ","Software-based security tool that protect data in cloud services"));
        cardList.Add(new Card(13, "Password Update", "Security", "Offense", 3, 130, "Deal 130 damage", Resources.Load<Sprite>("CardImages/Card 13"), 0, 0, 0,0,0,0, " ","Change password once in a while"));
        cardList.Add(new Card(14, "DNS Filtering", "Security", "Offense", 3, 100, "Instantly draw 1 card and deal 100 damage", Resources.Load<Sprite>("CardImages/Card 14"), 0, 0, 0,0,1,0, " ","Block access to malicious websites through DNS settings"));
        cardList.Add(new Card(15, "Privacy Settings", "Security", "Offense", 4, 160, "Deal 160 damage", Resources.Load<Sprite>("CardImages/Card 15"), 0, 0, 0,0,0,0, " ","Privacy settings allow you to control the personal information you share online"));
        cardList.Add(new Card(16, "Wi-Fi Encrpytion", "Security", "Offense", 4, 160, "Deal 160 damage", Resources.Load<Sprite>("CardImages/Card 16"), 0, 0, 0,0,0,0, " ","Secure your wi-fi connection by scrambling data sent to your network"));
        cardList.Add(new Card(17, "Anti-Malware", "Security", "Offense", 4, 0, "Deal 75  true damage", Resources.Load<Sprite>("CardImages/Card 17"), 0, 0, 0,0,0,75, " ","Secure your wi-fi connection by scrambling data sent to your network"));
        cardList.Add(new Card(18, "Penetration Testing", "Security", "Offense", 5, 220, "Deal 220 damage", Resources.Load<Sprite>("CardImages/Card 18"), 0, 0, 0,0,0,0, " ","Use to prevent, detect, and remove malware to protect the device"));
        cardList.Add(new Card(19, "Whitelisting", "Security", "Offense", 5, 0, "Deal 100 true damage", Resources.Load<Sprite>("CardImages/Card 19"), 0, 0, 0,0,0,100, " ","Software that only allow approved applications to access system"));
        cardList.Add(new Card(20, "Backup Files", "Security", "Defense", 1, 0, "Gain 30 shield", Resources.Load<Sprite>("CardImages/Card 20"), 0, 0, 30,0,0,0, " ","Create copy of your data to ensure you can recover important information"));
        cardList.Add(new Card(21, "VPN", "Security", "Defense", 1, 0, "Gain 20 shield", Resources.Load <Sprite> ("CardImages/Card 21"), 0,0, 20,0,0,0, " ","Makes  internet connection more secure by encrypting it in a secure server"));
        cardList.Add(new Card(22, "Connection Caution", "Security", "Defense", 1, 0, "Gain 30 shield", Resources.Load<Sprite>("CardImages/Card 22"), 0, 0, 30,0,0,0, " ","Careful with connecting to unknown devices"));
        cardList.Add(new Card(23, "Avoid Ads", "Security", "Defense", 1, 0, "Gain 30 shield", Resources.Load<Sprite>("CardImages/Card 23"), 0, 0, 30,0,0,0, " ","Avoid clicking unknown advertisements"));
        cardList.Add(new Card(24, "PassManager", "Security", "Defense", 1, 0, "Gain 30 shield", Resources.Load<Sprite>("CardImages/Card 24"), 0, 0, 30,0,0,0, " ","Store password in Password Manager"));
        cardList.Add(new Card(25, "LogOut Accounts", "Security", "Defense", 2, 0, "Gain 60 shield", Resources.Load<Sprite>("CardImages/Card 25"), 0, 0, 60,0,0,0, " ","Logout accounts after using it to prevent unauthorized access"));
        cardList.Add(new Card(26, "ActivityAlert", "Security", "Defense", 2, 0, "Gain 60 shield", Resources.Load<Sprite>("CardImages/Card 26"), 0, 0, 60,0,0,0, " ","Setup account alert to get notified if someone tried to login in your account"));
        cardList.Add(new Card(27, "NoPirated Soft", "Security", "Defense", 2, 0, "Gain 50 shield", Resources.Load<Sprite>("CardImages/Card 27"), 0, 0, 50,0,0,0, " ","Avoid pirated software as it can expose you to malware"));
        cardList.Add(new Card(28, "Access Control", "Security", "Defense", 2, 0, "Instantly draw 1 card and gain 40 shield", Resources.Load<Sprite>("CardImages/Card 28"), 0, 0, 40,1,0,0, " ","Security method that only allows authorized user can gain access"));
        cardList.Add(new Card(29, "Email Filtering", "Security", "Defense", 2, 0, "Gain 70 shield", Resources.Load<Sprite>("CardImages/Card 29"), 0, 0, 70,0,0,0, " ","It sorts and block unwanted emails, such as spam or phishing attempts"));
        cardList.Add(new Card(30, "Avoid Sus Emails", "Security", "Defense", 3, 0, "Gain 100 shield", Resources.Load<Sprite>("CardImages/Card 30"), 0, 0, 80,0,0,0, " ","Avoid suspicious email from unknown senders"));
        cardList.Add(new Card(31, "PeriodScan", "Security", "Defense", 3, 0, "Gain 80 shield", Resources.Load<Sprite>("CardImages/Card 31"), 0, 0, 80,0,0,0, " ","Schedule a scan to check vulnerabilities in the software and system"));
        cardList.Add(new Card(32, "HTTPS Connection", "Security", "Defense", 3, 0, "Gain 60 shield", Resources.Load<Sprite>("CardImages/Card 32"), 0, 0, 60,0,0,0, " ","Encrypts data between your browser and website for a secure connection"));
        cardList.Add(new Card(33, "PatternLock", "Security", "Defense", 3, 0, "Gain 90 shield", Resources.Load<Sprite>("CardImages/Card 33"), 0, 0, 90,0,0,0, " ","Using pattern security before opening the device"));
        cardList.Add(new Card(34, "Clear Cookies", "Security", "Defense", 3, 0, "Gain 80 shield", Resources.Load<Sprite>("CardImages/Card 34"), 0, 0, 80,0,0,0, " ","Clear cookies to mitigate risk of session hijacking"));
        cardList.Add(new Card(35, "PinLock", "Security", "Defense", 4, 0, "Gain 120 shield", Resources.Load<Sprite>("CardImages/Card 35"), 0, 0, 120,0,0,0, " ","Use pin lock a combination of numbers"));
        cardList.Add(new Card(36, "Lock Computer", "Security", "Defense", 4, 0, "Gain 100 shield", Resources.Load<Sprite>("CardImages/Card 36"), 0, 0, 100,0,0,0, " ","Lock computer if need to leave to avoid unauthorized access"));
        cardList.Add(new Card(37, "Disable Bluetooth", "Security", "Defense", 4, 0, "Gain 120 shield", Resources.Load<Sprite>("CardImages/Card 37"), 0, 0, 120,0,0,0, " ","Disable Bluetooth to avoid unauthorized access and data theft"));
        cardList.Add(new Card(38, "Fingerprint Biometrics", "Security", "Defense", 5, 0, "Gain 130 shield", Resources.Load<Sprite>("CardImages/Card 38"), 0, 0, 130,0,0,0, " ","Using fingerprint for authentication to login or open account"));
        cardList.Add(new Card(39, "Facial Recognition", "Security", "Defense", 5, 0, "Gain 170 shield", Resources.Load<Sprite>("CardImages/Card 39"), 0, 0, 170,0,0,0, " ","Using facial features to login or open account"));
        cardList.Add(new Card(40, "Software Update", "Security", "Utility", 1, 0, "Recover 40 health points", Resources.Load<Sprite>("CardImages/Card 40"), 0, 40, 0,1,1,0, " ","Update software to latest version to patch up security flaws"));
        cardList.Add(new Card(41, "Soft Token", "Security", "Utility", 0, 0, "Instantly gain 1 Data Fragment", Resources.Load <Sprite> ("CardImages/Card 41"), 0,0, 0,0,1,0, " ","Software-based security token that generate one time password"));
        cardList.Add(new Card(42, "Hard Token", "Security", "Utility", 2, 0, "Instantly draw 1 card", Resources.Load<Sprite>("CardImages/Card 42"), 0, 60, 0,1,0,0, " ","Small hardware device to authorize access to a network service"));
        cardList.Add(new Card(43, "Data Archiving", "Security", "Utility", 2, 90, "Deal 50 damage and gain 30 shield", Resources.Load<Sprite>("CardImages/Card 43"), 0, 0, 60,0,0,0, " ","Moving old or unused data in a safe place to be kept for long time"));
        cardList.Add(new Card(44, "AppChecker", "Security", "Utility", 3, 50, "Recover 80 hp and deal 50 damage to enemy", Resources.Load<Sprite>("CardImages/Card 44"), 0, 80, 0,0,0,0, " ","Check if there is suspicious application you didn't install"));
        cardList.Add(new Card(45, "NoSamePassword", "Security", "Utility", 3, 0, "Instantly draw 1 card and gain 4 energy", Resources.Load<Sprite>("CardImages/Card 45"), 2, 0, 0,1,4,0, " ","Avoid using same password across accounts"));
        cardList.Add(new Card(46, "AppPermission", "Security", "Utility", 4, 50, "Deal 50 damage and recover 70 health points", Resources.Load<Sprite>("CardImages/Card 46"), 0, 70, 0,0,0,0, " ","Check App permission as it ask for some permission that aren't needed"));
        cardList.Add(new Card(47, "AccRecovery", "Security", "Utility", 4, 0, "Instantly draw 3 cards", Resources.Load<Sprite>("CardImages/Card 47"), 0, 0, 0,3,0,0, " ","Account Recovery will let you regain access to your account"));
        cardList.Add(new Card(48, "Network Security", "Security", "Utility", 5, 160, "Deal 110 damage and gain 2 energy", Resources.Load<Sprite>("CardImages/Card 48"), 0, 0, 0,0,2,0, " ","Protect the network and data from attacks and unauthorized access"));
        cardList.Add(new Card(49, "Cryptography", "Security", "Utility", 5, 0, "Recover 120 health points", Resources.Load<Sprite>("CardImages/Card 49"), 0, 120, 0,0,0,0, " ","Encrypt information in unreadable format, can be recover by decryption"));
        cardList.Add(new Card(50, "Adware", "Threat", "Offense", 1, 80, "Deal 80 Damage", Resources.Load<Sprite>("CardImages/Card 50"), 0, 0, 0,0,0,0, " ","Display pre-chosen advetisements on the system"));
        cardList.Add(new Card(51, "Ransomware", "Threat", "Offense", 1, 90, "Deal 90 Damage", Resources.Load <Sprite> ("CardImages/Card 51"), 0,0, 0,0,0,0, " ","Lock files and wait for the user to pay to unlock the files"));
        cardList.Add(new Card(52, "Worm", "Threat", "Offense", 1, 80, "Deal 80 Damage", Resources.Load<Sprite>("CardImages/Card 52"), 0, 0, 0,0,0,0, " ","Spread copies of itself which can eat the free space "));
        cardList.Add(new Card(53, "Trojan", "Threat", "Offense", 1, 90, "Deal 90 Damage", Resources.Load<Sprite>("CardImages/Card 53"), 0, 0, 0,0,0,0, " ","Fake software that looks legitimate and can take control of computer"));
        cardList.Add(new Card(54, "Brute Force", "Threat", "Offense", 1, 80, "Deal 80 Damage", Resources.Load<Sprite>("CardImages/Card 54"), 0, 0, 0,0,0,0, " ","It is an attempt to guess password until the correct one is found"));
        cardList.Add(new Card(55, "Denial-of -Service", "Threat", "Offense", 2, 90, "Deal 90 Damage", Resources.Load<Sprite>("CardImages/Card 55"), 0, 0, 0,0,0,0, " ","It is making the server or network unavailable by overwhelming a server"));
        cardList.Add(new Card(56, "Spam", "Threat", "Offense", 2, 100, "Deal 100 Damage", Resources.Load<Sprite>("CardImages/Card 56"), 0, 0, 0,0,0,0, " ","It is a junk e-mail sent to a large number of recipients"));
        cardList.Add(new Card(57, "Spoofing", "Threat", "Offense", 2, 110, "Deal 110 Damage", Resources.Load<Sprite>("CardImages/Card 57"), 1, 0, 0,0,0,0, " ","It is a technique used to gain unauthorized access to a computer"));
        cardList.Add(new Card(58, "Bot", "Threat", "Offense", 2, 110, "Deal 110 Damage", Resources.Load<Sprite>("CardImages/Card 58"), 0, 0, 0,0,0,0, " ","It performs repetitive task that can be used to execute attacks or spread spam"));
        cardList.Add(new Card(59, "Backdoor", "Threat", "Offense", 2, 100, "Deal 100 Damage", Resources.Load<Sprite>("CardImages/Card 59"), 0, 0, 0,0,0,0, " ","It is a hidden entry in the device or software that bypasses security"));
        cardList.Add(new Card(60, "Redirect Browsing", "Threat", "Offense", 3, 110, "Deal 110 damage", Resources.Load<Sprite>("CardImages/Card 60"), 0, 0, 0,0,0,0, " ","Trick user to click links that lead them to harmful sites"));
        cardList.Add(new Card(61, "Shrink Wrap Code", "Threat", "Offense", 3, 100, "Instantly draw 1 card and deal 100 damage", Resources.Load<Sprite>("CardImages/Card 61"), 0, 0, 0,1,0,0, " ","It is an act of exploiting unpatched or poorly configurated software"));
        cardList.Add(new Card(62, "Cloud Exploitation", "Threat", "Offense", 3, 120, "Deal 140 Damage", Resources.Load<Sprite>("CardImages/Card 62"), 0, 0, 0,0,0,0, " ","Exploit vulnerabilities within cloud services to gain unauthorized access"));
        cardList.Add(new Card(63, "Zombie Drone", "Threat", "Offense", 3, 110, "Deal 130 Damage", Resources.Load<Sprite>("CardImages/Card 63"), 0, 0, 0,0,0,0, " ","Hi-jacked computer that is being used as a soldier for malicious activity"));
        cardList.Add(new Card(64, "Network Attack", "Threat", "Offense", 3, 130, "Deal 130 damage", Resources.Load<Sprite>("CardImages/Card 64"), 0, 0, 0,0,0,0, " ","It is to dirsrupt, disable or gain access to a computer network"));
        cardList.Add(new Card(65, "DDOS", "Threat", "Offense", 4, 140, "Deal 140 damage", Resources.Load<Sprite>("CardImages/Card 65"), 0, 0, 0,0,0,0, " ","It's an attack that overwhelms a network with excessive traffic, causing it to slow down"));
        cardList.Add(new Card(66, "Session Hijacking", "Threat", "Offense", 4, 130, "Instantly gain 1 data fragment and deal 130 Damage", Resources.Load<Sprite>("CardImages/Card 66"), 0, 0, 0,0,1,0, " ","Take control of user's active session using stolen session tokens to get important information"));
        cardList.Add(new Card(67, "Session Spoofing", "Threat", "Offense", 4, 0, "Deal 75 true damage.", Resources.Load<Sprite>("CardImages/Card 67"), 0, 0, 0,0,0,75, " ","Impersonate a legitimate user session to gain unauthorized access"));
        cardList.Add(new Card(68, "DNS Spoofing", "Threat", "Offense", 5, 220, "Deal 220 Damage", Resources.Load<Sprite>("CardImages/Card 68"), 0, 0, 0,0,0,0, " ","Hijack by redirecting to malicious sites"));
        cardList.Add(new Card(69, "Cookie Theft", "Threat", "Offense", 5, 0, "Deal 100 true damage", Resources.Load<Sprite>("CardImages/Card 69"), 0, 0, 0,0,0,100, " ","Capture cookies to hijack social media sessions to gain access"));
        cardList.Add(new Card(70, "Spyware", "Threat", "Defense", 1, 0, "Gain 30 shield.", Resources.Load<Sprite>("CardImages/Card 70"), 0, 0, 30,0,0,0, " ","Infiltrates a computing device and steals internet usage data and senstive information"));
        cardList.Add(new Card(71, "Key Logger", "Threat", "Defense", 1, 0, "Gain 30 shield.", Resources.Load <Sprite> ("CardImages/Card 71"), 0,0, 30, 0,0,0, " ","It tracks keys which are pressed on a computer to capture sensitive information"));
        cardList.Add(new Card(72, "Phishing", "Threat", "Defense", 1, 0, "Gain 40 shield.", Resources.Load<Sprite>("CardImages/Card 72"), 0, 0, 40,0,0,0, " ","It is an email fraud method in attempt to gather sensitive information"));
        cardList.Add(new Card(73, "Exploit", "Threat", "Defense", 1, 0, "Gain 30 shield.", Resources.Load<Sprite>("CardImages/Card 73"), 0, 0, 30,0,0,0, " ","Sequence of command that takes advantage of a bug or vulnerability to enter the system"));
        cardList.Add(new Card(74, "Logic Bomb", "Threat", "Defense", 1, 0, "Gain 40 shield.", Resources.Load<Sprite>("CardImages/Card 74"), 0, 0, 40,0,0,0, " ","It activates when a certain condition are met which can cause damage"));
        cardList.Add(new Card(75, "Rootkit", "Threat", "Defense", 2, 0, "Gain 60 shield.", Resources.Load<Sprite>("CardImages/Card 75"), 0, 0, 60,0,0,0, " ","It hides its presence and lets attackers control the system undetected"));
        cardList.Add(new Card(76, "Cross Site Scripting", "Threat", "Defense", 2, 0, "Gain 70 shield.", Resources.Load<Sprite>("CardImages/Card 76"), 0, 0, 70,0,0,0, " ","Allows attackers to inject scripts in web pages to steal sensitive information"));
        cardList.Add(new Card(77, "AutoDownload", "Threat", "Defense", 2, 0, "Gain 70 shield.", Resources.Load<Sprite>("CardImages/Card 77"), 0, 0, 70,0,0,0, " ","Automatilly download malicious software without user's consent"));
        cardList.Add(new Card(78, "Social Engineering", "Threat", "Defense", 2, 0, "Gain 90 shields", Resources.Load<Sprite>("CardImages/Card 78"), 0, 0, 50,0,0,0, " ","Tricking someone into revealing their password to attacker or allow access"));
        cardList.Add(new Card(79, "SQL Injection", "Threat", "Defense", 2, 0, "Gain 60 shield.", Resources.Load<Sprite>("CardImages/Card 79"), 0, 0, 60,0,0,0, " ","It let attackers manipulate databases by inserting malicious SQL code in input fields"));
        cardList.Add(new Card(80, "Data Breach", "Threat", "Defense", 3, 0, "Instantly draw 1 card and gain 60 shield", Resources.Load<Sprite>("CardImages/Card 80"), 0, 0, 60,1,0,0, " ","Gain unauthorized access to steal sensitive information"));
        cardList.Add(new Card(81, "Phreakers", "Threat", "Defense", 3, 0, "Gain 100 shield", Resources.Load<Sprite>("CardImages/Card 81"), 0, 0, 100,0,0,0, " ","Original computer hacker that breaks into telephone network illegally"));
        cardList.Add(new Card(82, "Digital Skimming", "Threat", "Defense", 3, 0, "Gain 90 shield.", Resources.Load<Sprite>("CardImages/Card 82"), 0, 0, 90,0,0,0, " ","Capture payment information on online payment forms"));
        cardList.Add(new Card(83, "Cracker", "Threat", "Defense", 3, 0, "Gain 80 shield", Resources.Load<Sprite>("CardImages/Card 83"), 0, 0, 60,0,0,0, " ","Modify software to access features or bypass security measures to steal data"));
        cardList.Add(new Card(84, "BaitWare", "Threat", "Defense", 3, 0, "Gain 100 shield.", Resources.Load<Sprite>("CardImages/Card 84"), 0, 0, 100,0,0,0, " ","Freeware or Shareware that contains a malware"));
        cardList.Add(new Card(85, "Clickbait", "Threat", "Defense", 4, 0, "Gain 110 shield.", Resources.Load<Sprite>("CardImages/Card 85"), 0, 0, 110,0,0,0, " ","Misleading the user by using a catchy headline or image to trick them on clicking on it"));
        cardList.Add(new Card(86, "MailWare", "Threat", "Defense", 4, 0, "Gain 110 shield.", Resources.Load<Sprite>("CardImages/Card 86"), 0, 0, 110,0,0,0, " ","Malware in e-mail attachment"));
        cardList.Add(new Card(87, "Fake Mods", "Threat", "Defense", 4, 0, "Gain 120 shield", Resources.Load<Sprite>("CardImages/Card 87"), 0, 0, 70,0,0,0, " ","Insert Malware in game modification softwares"));
        cardList.Add(new Card(88, "Cryptomining", "Threat", "Defense", 5, 0, "Gain 140 shield.", Resources.Load<Sprite>("CardImages/Card 88"), 0, 0, 140,0,0,0, " ","Using someone's computer to mine cryptocurrency"));
        cardList.Add(new Card(89, "Bluetooth Attack", "Threat", "Defense", 5, 0, "Gain 130 shield.", Resources.Load<Sprite>("CardImages/Card 89"), 0, 0, 130,0,0,0, " ","Obtain data by exploiting bluetooth"));
        cardList.Add(new Card(90, "Software Exploitation", "Threat", "Utility", 0, 0, "Instantly gain 1 data fragment", Resources.Load<Sprite>("CardImages/Card 90"), 0, 0, 0,0,1, 0," ","Exploit software vulnerabilities to gain control or steal data"));
        cardList.Add(new Card(91, "USB Attack", "Threat", "Utility", 1, 40, "Deal 40 damage and 20 shield", Resources.Load <Sprite> ("CardImages/Card 91"), 0, 0, 20,0,0,0, " ","Implant malware or steal data by connecting to a computer"));
        cardList.Add(new Card(92, "Virus", "Threat", "Utility", 2, 0, "Regenerate 60 Health", Resources.Load<Sprite>("CardImages/Card 92"), 0, 60, 0,0,0,0, " ","Capable of copying itself and can corrupt system or destroy data"));
        cardList.Add(new Card(93, "Privilege Attack", "Threat", "Utility", 2, 0, "Recover 50 health points and gain 10 shield", Resources.Load<Sprite>("CardImages/Card 93"), 0, 50, 10,0,0, 0," ","Gain privilege access and exploit sensitive data that is only for authorized user"));
        cardList.Add(new Card(94, "Scareware", "Threat", "Utility", 3, 80, "Deal 80 damage this round", Resources.Load<Sprite>("CardImages/Card 94"), 1, 0, 0,0,0,0, " ","Trick the user into believing that their device is infected or at risk"));
        cardList.Add(new Card(95, "Crypting Services", "Threat", "Utility", 3, 0, "Recover 60 health points and Gain 20 shield", Resources.Load<Sprite>("CardImages/Card 95"), 0, 60, 20,0,0,0, " ","Encrypt malware to evade detection, making it difficult to be detected by security"));
        cardList.Add(new Card(96, "Browser Exploit", "Threat", "Utility", 4, 100, "Instantly draw 1 card and deal 100", Resources.Load<Sprite>("CardImages/Card 96"), 0, 0, 0,1,0,0, " ","Exploit browsers vulnerabilities"));
        cardList.Add(new Card(97, "Botnet", "Threat", "Utility", 4, 0, "Instantly draw 3 cards", Resources.Load<Sprite>("CardImages/Card 97"), 0, 0, 0,3,0,0, " ","Using infected device to attack"));
        cardList.Add(new Card(98, "Wi-Fi Cracking", "Threat", "Utility", 5, 100, "Instantly gain 2 data fragment and deal 100 damage", Resources.Load<Sprite>("CardImages/Card 98"), 0, 0, 0,0,2,0, " ","Use tools to guess Wi-Fi password"));
        cardList.Add(new Card(99, "SMS Attack", "Threat", "Utility", 5, 0, "Recover 120 health points", Resources.Load<Sprite>("CardImages/Card 99"), 0, 120, 0,0,0,0, " ","Sending links via SMS that contains a malware"));
        cardList.Add(new Card(100, "Security Defense Card", "Security", "Defense", 1, 0, "Gain 200 Shield", Resources.Load<Sprite>("CardImages/Card 95"), 0, 0, 200,0,0,0, " ","Beginner Card"));
        cardList.Add(new Card(101, "Security Offense Card", "Security", "Offense", 2, 300, "Deal 300 Damage", Resources.Load<Sprite>("CardImages/Card 96"), 0, 0, 0,0,0,0, " ","Beginner Card"));
        cardList.Add(new Card(102, "Security Utility Card", "Security", "Utility", 1, 0, "Recover 200 Health", Resources.Load<Sprite>("CardImages/Card 97"), 0, 200, 0,0,0,0, " ","Beginner Card"));
        cardList.Add(new Card(103, "Security Offense Card", "Security", "Offense", 4, 300, "Deal 300 Damage", Resources.Load<Sprite>("CardImages/Card 98"), 0, 0, 0,0,0,0, " ","Beginner Card"));
        cardList.Add(new Card(104, "Security Defense Card", "Security", "Defense", 1, 0, "Gain 200 Shield", Resources.Load<Sprite>("CardImages/Card 99"), 0, 0, 200,0,0,0, " ","Beginner Card"));
        cardList.Add(new Card(105, "Threat Defense Card", "Threat", "Defense", 1, 0, "Gain 50 Shield", Resources.Load<Sprite>("CardImages/Card 95"), 0, 0, 50,0,0, 0," ","Beginner Card"));
        cardList.Add(new Card(106, "Threat Offense Card", "Threat", "Offense", 2, 50, "Deal 50 Damage", Resources.Load<Sprite>("CardImages/Card 96"), 0, 0, 50,0,0,0, " ","Beginner Card"));
        cardList.Add(new Card(107, "Threat Utility Card", "Threat", "Utility", 1, 0, "Recover 50 Health", Resources.Load<Sprite>("CardImages/Card 97"), 0, 50, 0,0,0,0, " ","Beginner Card"));
        cardList.Add(new Card(108, "Threat Offense Card", "Threat", "Offense", 4, 50, "Deal 50 Damage", Resources.Load<Sprite>("CardImages/Card 98"), 0, 0, 0,0,0, 0," ","Beginner Card"));
        cardList.Add(new Card(109, "Threat Defense Card", "Threat", "Defense", 1, 0, "Gain 50 Shield", Resources.Load<Sprite>("CardImages/Card 99"), 0, 0, 50,0,0,0, " ","Beginner Card"));
    }
}
