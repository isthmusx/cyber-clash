using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "Phishing Reversal", "Security", "Offense", 1, 800, "Bait the enemy into revealing their identity. Deal 80 damage", Resources.Load<Sprite>("CardImages/RepairKitIMG"), 1, 0, 0,1));
        cardList.Add(new Card(1, "Ad Blocker", "Security", "Offense", 1, 70, "Remove ads from any sites.\nDeal 70 damage", Resources.Load <Sprite> ("CardImages/RepairKitIMG"), 1,0 , 0,1));
        cardList.Add(new Card(2, "Safety Net", "Security", "Offense", 1, 70, "Use secured Wi-Fi connection.\nDeal 70 damage", Resources.Load<Sprite>("CardImages/RepairKitIMG"), 1, 0, 0,1));
        cardList.Add(new Card(3, "Veiled Attack", "Security", "Offense", 1, 70, "Bypass enemy's detection system.\nDeal 70 damage", Resources.Load<Sprite>("CardImages/DemonIMG"), 1, 0, 0,1));
        cardList.Add(new Card(4, "Recharge[TEST]", "Security", "Offense", 1, 80, "If you damage the enemy more than 80 damage this round. Gain 2 extra energy round.", Resources.Load<Sprite>("CardImages/GodIMG"), 1, 0, 0,1));
        cardList.Add(new Card(5, "Fingerprint","Security", "Offense", 2, 100, "Use fingerprint for authentication.\nDeal 100 damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(6, "Tracker", "Security", "Offense", 2, 90, "Track the attacker's IP address.\nDeal 90 damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(7, "Cyber Tactics", "Security", "Offense", 2, 100, "Launch a tactical attack on the threat.\nDeal 100 damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(8, "Encryption Override", "Security", "Offense", 2, 90, "Override the enemy's data encryption.\nDeal 90 damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(9, "Network Overload", "Security", "Offense", 2, 100, "Overload the network of enemy making it slow.\nDeal 100 damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(10, "Decoy Network", "Security", "Offense", 3, 140, "Create fake network misleading the attacker.\nDeal 140 damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(11, "Bot Annihilator", "Security", "Offense", 3, 120, "Cleanse or remove any bot from network.\nDeal 120 damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(12, "Purge and Purify[TEST]", "Security", "Offense", 3, 120, "Clean the computer from any malware.\nDeal 120 damage and recover 50 health points", Resources.Load<Sprite>("Infiltrator"), 0, 50, 0,0));
        cardList.Add(new Card(13, "Hard Update", "Security", "Offense", 3, 130, "Update hardware components to improve performance of computer.\nDeal 130 damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(14, "Search n Destroy", "Security", "Offense", 3, 130, "Scan the computer from any malware.\nDeal 130 damage and gain 50 shield", Resources.Load<Sprite>("NoImage"), 0, 0, 50,0));
        cardList.Add(new Card(15, "Access Control", "Security", "Offense", 4, 160, "Have access control to limit unauthorized access.\nDeal 160 damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(16, "Backdoor Exploitation", "Security", "Offense", 4, 160, "Enter through attacker's software vulnerabilities.\nDeal 160 damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(17, "Data Corruption", "Security", "Offense", 4, 170, "Corrupt the data of attacker.\nDeal 140 damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(18, "Trick-O-Treat", "Security", "Offense", 5, 220, "Trick the attacker by deploying fake information.\nDeal 220 damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(19, "System Crasher", "Security", "Offense", 5, 190, "Make the system of crash making it unusable.\nDeal 190 true damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(20, "Strong Password", "Security", "Defense", 1, 0, "Have a strong password to have a better security.\nGain 30 shield", Resources.Load<Sprite>("NoImage"), 0, 0, 30,0));
        cardList.Add(new Card(21, "Safe Web Surfing", "Security", "Defense", 1, 0, "Use a host file to block web pages that might contain a malware.\nGain 20 shield", Resources.Load <Sprite> ("Infiltrator"), 0,0, 20,0));
        cardList.Add(new Card(22, "Take a byte", "Security", "Defense", 1, 0, "Create decoy to lead malicious malware into the system and eliminate the malware.\nGain 30 shield", Resources.Load<Sprite>("NoImage"), 0, 0, 30,0));
        cardList.Add(new Card(23, "Malware Isolation", "Security", "Defense", 1, 0, "Isolate malware and remove them all to prevent any damages.\nGain 30 shield", Resources.Load<Sprite>("NoImage"), 0, 0, 30,0));
        cardList.Add(new Card(24, "Data Loss Prevention", "Security", "Defense", 1, 0, "Safeguard data by monitoring unauthorized transfer of data.\nGain 30 shield", Resources.Load<Sprite>("NoImage"), 0, 0, 30,0));
        cardList.Add(new Card(25, "Bulwark", "Security", "Defense", 2, 0, "Update anti-virus software.\nGain 60 shield", Resources.Load<Sprite>("NoImage"), 0, 0, 60,0));
        cardList.Add(new Card(26, "MFA", "Security", "Defense", 2, 0, "Multi-Factor Authentication, requiring user to enter more than just a password.\nGain 60 shield", Resources.Load<Sprite>("NoImage"), 0, 0, 60,0));
        cardList.Add(new Card(27, "Disable Autorun", "Security", "Defense", 2, 0, "Limit the spread of malware by disabling auto run.\nGain 50 shield", Resources.Load<Sprite>("NoImage"), 0, 0, 50,0));
        cardList.Add(new Card(28, "Network Security", "Security", "Defense", 2, 0, "Check the network if there is any malicious activity.\nGain 40 shield", Resources.Load<Sprite>("NoImage"), 0, 0, 40,0));
        cardList.Add(new Card(29, "Proxy Server", "Security", "Defense", 2, 0, "Use proxy server to prevent cyber attackers entering private network.\nGain 70 shield", Resources.Load<Sprite>("NoImage"), 0, 0, 70,0));
        cardList.Add(new Card(30, "Encrypt Files", "Security", "Defense", 3, 0, "Protect the files by encrypting it.\nGain 100 shield", Resources.Load<Sprite>("NoImage"), 0, 0, 80,0));
        cardList.Add(new Card(31, "Backup Files", "Security", "Defense", 3, 0, "Have a backup for files incase it get deleted.\nGain 50 shield and recover 30 health points", Resources.Load<Sprite>("NoImage"), 0, 30, 50,0));
        cardList.Add(new Card(32, "Firewall", "Security", "Defense", 3, 40, "Activate Firewall to defend against attacker.\nGain 60 shield and deal 40 damage", Resources.Load<Sprite>("Infiltrator"), 0, 0, 60,0));
        cardList.Add(new Card(33, "Auto Update On", "Security", "Defense", 3, 0, "Turn on auto update on operating system to have the latest update and improve security. Gain 90 shield", Resources.Load<Sprite>("NoImage"), 0, 0, 90,0));
        cardList.Add(new Card(34, "File Vanguard", "Security", "Defense", 3, 0, "Check if any files are infected by a malware.\nGain 80 shield", Resources.Load<Sprite>("NoImage"), 0, 0, 80,0));
        cardList.Add(new Card(35, "Return to sender[TEST]", "Security", "Defense", 4, 0, "Any damage thrown to you in this round send it back to attacker, return 40% of it", Resources.Load<Sprite>("NoImage"), 0, 0, 40,0));
        cardList.Add(new Card(36, "Cloud Storage", "Security", "Defense", 4, 100, "Use a cloud storage and save important files in it.\nGain 100 shield", Resources.Load<Sprite>("NoImage"), 0, 0, 100,0));
        cardList.Add(new Card(37, "Clear Cookies", "Security", "Defense", 4, 0, "Clear web cookies to boost the performance of computer.\nGain 70 shield and recover 30 health points", Resources.Load<Sprite>("NoImage"), 0, 30, 70,0));
        cardList.Add(new Card(38, "Update Software", "Security", "Defense", 5, 0, "Update software, for next 3 rounds gain 60 shield per round.\nGain 40 shield per round in the next 3 rounds", Resources.Load<Sprite>("NoImage"), 0, 0, 40,0));
        cardList.Add(new Card(39, "2FA", "Security", "Defense", 5, 0, "Use two types of authentication factor.\nGain 170 shield", Resources.Load<Sprite>("NoImage"), 0, 0, 170,0));
        cardList.Add(new Card(40, "Temporary Files", "Security", "Utility", 1, 0, "Clean temporary files to free up improve computer performance.\nRecover 40 health points", Resources.Load<Sprite>("NoImage"), 0, 40, 0,0));
        cardList.Add(new Card(41, "Safe Booting[TEST]", "Security", "Utility", 1, 0, "Have a bootkit remover to prevent having a bootkit.\nGain 2 extra energy next round", Resources.Load <Sprite> ("Infiltrator"), 0,0, 0,0));
        cardList.Add(new Card(42, "HTTPS", "Security", "Utility", 2, 0, "Utilize HTTPS for a private and encrypted communication.\nRecover 60 health points", Resources.Load<Sprite>("NoImage"), 0, 60, 0,0));
        cardList.Add(new Card(43, "Cyber Amplifier[TEST]", "Security", "Utility", 2, 0, "In this round every damage card used will deal 20% more damage each card", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(44, "VampWall", "Security", "Utility", 3, 50, "If there is a missing health point recover 80 hp using Vampwall and deal 50 damage to enemy", Resources.Load<Sprite>("NoImage"), 0, 80, 0,0));
        cardList.Add(new Card(45, "Spyware", "Security", "Utility", 3, 0, "Send spyware to enemy to gain information on enemy.\nDraw extra 2 card next round", Resources.Load<Sprite>("NoImage"), 2, 0, 0,0));
        cardList.Add(new Card(46, "Trap Intrusion Alert", "Security", "Utility", 4, 50, "Detect if the enemy attack, deal 50 damage and recover 70 health points", Resources.Load<Sprite>("NoImage"), 0, 70, 0,0));
        cardList.Add(new Card(47, "Byte Boost[TEST]", "Security", "Utility", 4, 0, "Give extra 15% damage for every damage card that will be use in the next 3 rounds", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(48, "Red Alert[TEST]", "Security", "Utility", 5, 0, "Any damage receive this round recover and return 50% of the damage back to attacker", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(49, "Rearm Computer", "Security", "Utility", 5, 0, "Reset the network.\nRecover 120 health points", Resources.Load<Sprite>("NoImage"), 0, 120, 0,0));
        cardList.Add(new Card(50, "Steal Information", "Threat", "Offense", 1, 80, "Steal personal information of the defender.\nDeal 80 Damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(51, "Fake Files", "Threat", "Offense", 1, 90, "Create fake file consuming space from memory.\nDeal 90 Damage", Resources.Load <Sprite> ("Infiltrator"), 0,0, 0,0));
        cardList.Add(new Card(52, "Steal Data", "Threat", "Offense", 1, 80, "Steal personal information of the defender.\nDeal 80 Damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(53, "Copy Cat", "Threat", "Offense", 1, 90, "Disguise as a legit application.\nDeal 90 Damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(54, "Exploit System", "Threat", "Offense", 1, 80, "Exploit the weakness of a program or application in the system.\nDeal 80 Damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(55, "Bandwidth Interruptor", "Threat", "Offense", 2, 90, "Slow down the transfer speed of files.\nDeal 90 Damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(56, "Take Control", "Threat", "Offense", 2, 100, "Lock some of the files of the computer making it unusable.\nDeal 100 Damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(57, "Scareware", "Threat", "Offense", 2, 110, "Trick the defender that the computer is infected by a virus.\nDeal 110 Damage", Resources.Load<Sprite>("NoImage"), 1, 0, 0,0));
        cardList.Add(new Card(58, "Crysis", "Threat", "Offense", 2, 110, "Send a fake video game installer to defender.\nDeal 110 Damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(59, "Spoofed Mail", "Threat", "Offense", 2, 100, "Send email to the defender that contains a malware.\nDeal 100 Damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(60, "Exploit System[TEST]", "Threat", "Offense", 3, 0, "Weaken the defense of the system.\nDeal 10% more damage on the next 3 rounds", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(61, "Network Crash[TEST]", "Threat", "Offense", 3, 50, "Slow down the computer.\nFor 4 rounds each round the enemy will receive 50 damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(62, "DOS", "Threat", "Offense", 3, 140, "Denial of service by overloading network.\nDeal 140 Damage", Resources.Load<Sprite>("Infiltrator"), 0, 0, 0,0));
        cardList.Add(new Card(63, "Bricking", "Threat", "Offense", 3, 110, "Make the computer's hardware unusable.\nDeal 130 Damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(64, "Zombie Bot", "Threat", "Offense", 3, 130, "Group of infected computers by malware.\nDeal 130 damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(65, "File Duplicator", "Threat", "Offense", 4, 150, "Duplicate the files of the defender slowing the computer.\nDeal 150 damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(66, "File Destroyer", "Threat", "Offense", 4, 160, "Delete the files of the computer.\nDeal 160 Damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(67, "Bypass Security", "Threat", "Offense", 4, 140, "Gain access by bypassing the security of computer.\nDeal 140 true damage.", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(68, "File Corruptor", "Threat", "Offense", 5, 220, "Corrupt the files of the enemy.\nDeal 220 Damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(69, "Brute Force", "Threat", "Offense", 5, 180, 
            
            "Have access to computer files.\nDeal 180 true damage", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(70, "Network Isolation", "Threat", "Defense", 1, 0, "Have no connection to other computers to have more security.\nGain 30 shield.", Resources.Load<Sprite>("NoImage"), 0, 0, 30,0));
        cardList.Add(new Card(71, "Cryptography", "Threat", "Defense", 1, 0, "Hide all files or information of threat.\nGain 30 shield.", Resources.Load <Sprite> ("Infiltrator"), 0,0, 30,0));
        cardList.Add(new Card(72, "Evasive Protocol", "Threat", "Defense", 1, 0, "Evade any attempt of getting trace by defender.\nGain 40 shield.", Resources.Load<Sprite>("NoImage"), 0, 0, 40,0));
        cardList.Add(new Card(73, "Safe Surf", "Threat", "Defense", 1, 0, "Remove tracks from browsing in internet web browser.\nGain 30 shield.", Resources.Load<Sprite>("NoImage"), 0, 0, 30,0));
        cardList.Add(new Card(74, "Mix n` Match", "Threat", "Defense", 1, 0, "Mix some important information with fake information.\nGain 40 shield.", Resources.Load<Sprite>("NoImage"), 0, 0, 40,0));
        cardList.Add(new Card(75, "Malicious Barrier", "Threat", "Defense", 2, 0, "Hide the true objectives of the attack.\nGain 60 shield.", Resources.Load<Sprite>("NoImage"), 0, 0, 60,0));
        cardList.Add(new Card(76, "Secured Communication", "Threat", "Defense", 2, 0, "Use secured communications to avoid getting tracked.\nGain 70 shield.", Resources.Load<Sprite>("NoImage"), 0, 0, 70,0));
        cardList.Add(new Card(77, "Darknet Network", "Threat", "Defense", 2, 0, "Use Darknet for secured connection.\nGain 70 shield.", Resources.Load<Sprite>("NoImage"), 0, 0, 70,0));
        cardList.Add(new Card(78, "Deceit", "Threat", "Defense", 2, 40, "Trick the defender by giving false information.\nGain 50 shield and deal 40 damage.", Resources.Load<Sprite>("NoImage"), 0, 0, 50,0));
        cardList.Add(new Card(79, "Cookie Eater", "Threat", "Defense", 2, 0, "Remove cookies from web browser for secured connection.\nGain 60 shield.", Resources.Load<Sprite>("NoImage"), 0, 0, 60,0));
        cardList.Add(new Card(80, "Deceptive Entry", "Threat", "Defense", 3, 50, "Mislead the defender's attack.\nGain 60 shield and deal 50 damage.", Resources.Load<Sprite>("NoImage"), 0, 0, 60,0));
        cardList.Add(new Card(81, "Guardian's Protection", "Threat", "Defense", 3, 0, "Update all software of attacker.\nGain 50 shield and recover 20 health points.", Resources.Load<Sprite>("NoImage"), 0, 20, 50,0));
        cardList.Add(new Card(82, "DDoS", "Threat", "Defense", 3, 0, "Distributed Denial of Service to overload network.\nGain 90 shield.", Resources.Load<Sprite>("Infiltrator"), 0, 0, 90,0));
        cardList.Add(new Card(83, "Cloak Malware", "Threat", "Defense", 3, 50, "Hide network and send a malware to defender.\nGain 60 shield and deal 50 damage.", Resources.Load<Sprite>("NoImage"), 0, 0, 60,0));
        cardList.Add(new Card(84, "Data Dump", "Threat", "Defense", 3, 0, "Clear all data of computer to incase of getting tracked by defender.\nGain 100 shield.", Resources.Load<Sprite>("NoImage"), 0, 0, 100,0));
        cardList.Add(new Card(85, "Threat Fortification", "Threat", "Defense", 4, 0, "Activate the anti virus software.\nGain 110 shield.", Resources.Load<Sprite>("NoImage"), 0, 0, 110,0));
        cardList.Add(new Card(86, "Ethereal Wall", "Threat", "Defense", 4, 0, "Activate the firewall of attacker.\nGain 110 shield.", Resources.Load<Sprite>("NoImage"), 0, 0, 110,0));
        cardList.Add(new Card(87, "Dummy Email", "Threat", "Defense", 4, 60, "Trick the opponent with a fake email.\nGain 70 shield and deal 60 damage.", Resources.Load<Sprite>("NoImage"), 0, 0, 70,0));
        cardList.Add(new Card(88, "VPN", "Threat", "Defense", 5, 0, "Hide IP address from defender.\nGain 140 shield.", Resources.Load<Sprite>("NoImage"), 0, 0, 140,0));
        cardList.Add(new Card(89, "Encryption", "Threat", "Defense", 5, 100, "Encrypt files to prevent unauthorized access.\nGain 130 shield.", Resources.Load<Sprite>("NoImage"), 0, 0, 130,0));
        cardList.Add(new Card(90, "Bypass Firewall", "Threat", "Utility", 1, 0, "Bypass the enemy's firewall.\nRecover 30 health points", Resources.Load<Sprite>("NoImage"), 0, 30, 0,0));
        cardList.Add(new Card(91, "Cyber Trap[TEST]", "Threat", "Utility", 1, 0, "If you get attack this round gain 2 extra energy.", Resources.Load <Sprite> ("Infiltrator"), 0, 0, 0,0));
        cardList.Add(new Card(92, "Network Recovery", "Threat", "Utility", 2, 0, "Reset the network.\nRegenerate 60 Health", Resources.Load<Sprite>("NoImage"), 0, 60, 0,0));
        cardList.Add(new Card(93, "Network Purification", "Threat", "Utility", 2, 0, "Removing any tracks from network.\nRecover 50 health points and gain 10 shield", Resources.Load<Sprite>("NoImage"), 0, 50, 10,0));
        cardList.Add(new Card(94, "Cyber Surveillance", "Threat", "Utility", 3, 80, "Monitor the enemy movement.\nDraw 1 extra card next round and deal 80 damage this round", Resources.Load<Sprite>("NoImage"), 1, 0, 0,0));
        cardList.Add(new Card(95, "Clear Cache", "Threat", "Utility", 3, 0, "Boost browsing experience and improve security.\nRecover 60 health points and Gain 20 shield", Resources.Load<Sprite>("NoImage"), 0, 60, 20,0));
        cardList.Add(new Card(96, "Dropper[TEST]", "Threat", "Utility", 4, 0, "Harmless but brings other kind of malware with it.\nGain 20% more damage on the next 2 rounds", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(97, "Computer Overclock[TEST]", "Threat", "Utility", 4, 0, "Run computer's processor at a higher rate.\nDo extra 15% damage for next round per card", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(98, "Security Disabler", "Threat", "Utility", 5, 120, "Disable the system making it vulnerable.\nIgnore shield, deal 120 damage and draw 1 extra card next round", Resources.Load<Sprite>("NoImage"), 0, 0, 0,0));
        cardList.Add(new Card(99, "Repair Kit", "Threat", "Utility", 5, 0, "Remove any debuff.\nRecover 100 health points", Resources.Load<Sprite>("CardImages/RepairKitIMG"), 0, 100, 0,0));
        
    }
}
