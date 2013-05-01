using System.Collections.Generic;
using System.Net.Sockets;

	class Program
{
	
	static void Main() {
		//byte[] macAddress = new byte[] {0x00, 0x1e, 0x90, 0xee, 0x43, 0x5f}; 
		byte[] macAddress = new byte[] {0x00, 0x21, 0x9b, 0x16, 0xa0, 0x42}; 

		//Construct the packet 
		List<byte> packet = new List<byte>(); 

		//6 FF packets 
		for (int i = 0; i < 6; i++) 
		packet.Add(0xFF); 

		//Repeat 16 time the MAC address (which is 6 bytes) 
		for (int i = 0; i < 16; i++) 
		packet.AddRange(macAddress);
		
		//Send the packet to broadcast address 
		UdpClient client = new UdpClient(); 
		client.Connect(System.Net.IPAddress.Broadcast, 4000);
		client.Send(packet.ToArray(), packet.Count);
	}

}