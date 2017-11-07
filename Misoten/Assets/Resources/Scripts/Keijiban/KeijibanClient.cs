using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class KeijibanClient : MonoBehaviour {

    public string ipAddress;    //IPアドレス
    public int port;         //ポート番号

    TcpClient tcp;
    NetworkStream ns;

	// Use this for initialization
	void Start () {
        tcp = new TcpClient(ipAddress,port);

        ns = tcp.GetStream();

        byte[] sendBytes = Encoding.UTF8.GetBytes("yaju.jpg");

        ns.Write(sendBytes,0, sendBytes.Length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
