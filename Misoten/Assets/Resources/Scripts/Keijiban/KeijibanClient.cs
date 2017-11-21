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
    static NetworkStream ns;

	// Use this for initialization
	void Start () {
        tcp = new TcpClient(ipAddress,port);

        ns = tcp.GetStream();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //どちらのプレイヤーが優勢かを判断しデータを送信する
        //SendData(0);
	}

    static public void SendData(string data)
    {
        byte[] sendBytes = Encoding.UTF8.GetBytes(data);

        ns.Write(sendBytes,0,sendBytes.Length);
    }
}
