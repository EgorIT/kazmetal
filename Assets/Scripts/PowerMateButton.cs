using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class PowerMateButton : MonoBehaviour {
    private const int unityPort = 47000;
    private UdpClient listener;
    private IPEndPoint groupEP;
    private Thread listenThread;
    private bool work = false;

    public bool rotateLeft = false;
    public bool rotateRight = false;
    public bool press = false;
    public bool longPress = false;
    public float speed;

    public Action onPress;
    public Action onLongPress;
    public Action<float> onRotate;

    // Use this for initialization
    void Start () {
        listener = new UdpClient(unityPort);
        groupEP = new IPEndPoint(IPAddress.Any, unityPort);
        work = true;
        listenThread = new Thread(udpWorker);
        listenThread.Start();
    }

    void OnDestroy()
    {
        work = false;
        listenThread.Join();
    }

    // Update is called once per frame
    void FixedUpdate () {
        processUnityEvents();
    }

    private void processUnityEvents()
    {
        if (rotateLeft || rotateRight)
        {
            onRotate(speed);
            speed = Mathf.Lerp(speed, 0, Time.deltaTime * 10.0f);
            if (Mathf.Abs(speed) < 0.001)
            {
                speed = 0;
                rotateLeft = false;
                rotateRight = false;
            }
        }

        if (press)
        {
            onPress();
            press = false;
        }

        if (longPress)
        {
            onLongPress();
            longPress = false;
        }
    }

    private void udpWorker()
    {
        //Debug.Log("start udpWorker");
        while (work)
        {
            if (listener.Available > 0)
            {
                byte[] data = listener.Receive(ref groupEP);
                string msg = System.Text.Encoding.ASCII.GetString(data, 0, data.Length);
                parsePowermateAction(int.Parse(msg));
            }
            else
            {
                Thread.Sleep(1);
            }
        }
        //Debug.Log("close udpWorker");
    }

    private void parsePowermateAction(int action)
    {
        switch (action)
        {
            case 68:
            case 70:
                {
                    if (rotateLeft)
                    {
                        speed = 0;
                        rotateLeft = false;
                    }

                    rotateRight = true;

                    speed++;

                    if (action == 70)
                        press = true;
                    else
                        press = false;

                    break;
                }
            case 67:
            case 69:
                {
                    if (rotateRight)
                    {
                        speed = 0;
                        rotateRight = false;
                    }

                    speed--;
                    rotateLeft = true;

                    if (action == 69)
                        press = true;
                    else
                        press = false;
                    break;
                }
            case 65:
                {
                    press = true;
                    break;
                }
            case 72: // 1 sec longPress timer
            case 73: // 2 sec longPress timer
            case 74: // 3 sec longPress timer
            case 75: // 4 sec longPress timer
            case 76: // 5 sec longPress timer
            case 77: // 6 sec longPress timer
                {

                    break;
                }
            case 66:
                {
                    longPress = true;
                    break;
                }
            default:
                {
                    Debug.Log("got unknown action " + action);
                    break;
                }
        }
    }
}
