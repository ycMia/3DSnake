using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public bool paused = false;

    public Scrollbar scrollbar;
    public Text breakText;
    public Text textSpeed;
    public Text textScore;
    public Toggle cageToggle;

    public GameObject cage;
    public GameObject snakeBody;
    public GameObject bin;
    public GameObject appleBin;
    //public Button btx1;
    //public Button btx0;
    //public Button bty1;
    //public Button bty0;
    //public Button btz1;
    //public Button btz0;

    //class Snake
    //{
    //    public:
    //    void Init(Node* first, Node* last, int length);
    //    Snake(int length);
    //    void PrintApple();
    //    void CreateApple();
    //    bool IsEatingApple();
    //    bool IsEatingSelf();
    //    void PrintSnake();
    //    Node* GetForwardNode();
    //    void Move();
    //    void ExDestnation(int d);
    //    int AskIfEx();
    //    void Refresh();
    //    void Rend();

    //    private:
    //     bool _Renderer[8][8] [8];//true 亮
    //     int _length;
    //    Node* _tail = new Node;
    //    Node* _head = new Node;
    //    Apple _apple;
    //    int _destnation = 0;//相对世界的上下左右前后,即接入的数据
    //};
    //以上是c++的Snake

    public class Node
    {
        public Node(){ }
        public Node(Node theNode)
        {
            position = theNode.position;
            _next = theNode._next;
            _pre = theNode._pre;
        }
        
        public Node(int x,int y,int z)
        {
            position = new Vector3(x, y, z);
        }
        public Node(int x, int y, int z,Node next,Node pre)
        {
            position = new Vector3(x, y, z);
            _next = next;
            _pre = pre;
        }

        public Node(float x, float y, float z)
        {
            position = new Vector3(x, y, z);
        }
        public Node(float x, float y, float z, Node next, Node pre)
        {
            position = new Vector3(x, y, z);
            _next = next;
            _pre = pre;
        }
        //construct function
        public void ExPosition(int x, int y, int z)
        {
            position = new Vector3(x, y, z);
        }
        public void ExPosition(float x, float y, float z)
        {
            position = new Vector3(x, y, z);
        }

        //public void ConnectNext(Node node)
        //{
        //    _next = node;
        //}
        //public void ConnectPre(Node node)
        //{
        //    _pre = node;
        //}
        //public Vector3 GetPosition()
        //{
        //    return position;
        //}

        //这两段删除,请只在需要private的时候使用private,徒增麻烦

        public Vector3 position;
        //default is not real
        public   Node _next;
        public   Node _pre;
    }

    public class Snake
    {
        //private int globalcount = 1;
        
        private void _Init(ref Node first, ref Node last,int length)
        {
            //Debug.Log(length);
            Node middle = new Node(first.position.x-1, first.position.y, first.position.z,first,last);
            first._pre = middle;
            if(length>0)
            {
                length = length - 1;
                _Init(ref middle, ref _tail, length);
            }
            else
                last = new Node(middle.position.x - 1, middle.position.y, middle.position.z, middle, null);
        }

        public Snake()
        {

        }

        public Snake(int length,Gamemanager gamemanager)
        {
            //gameObjApple = Instantiate(_gamemanager.snakeBody) as GameObject;

            _gamemanager = gamemanager;
            _length = length;
            
            _Init(ref _head,ref _tail,length);
            CreateApple();
        }

        public void PrintSnake(int mode)//mode 1=>Debug.log()  mode 2=>Renderering
        {
            Node pointer = new Node(_head);
            visualHead = pointer.position;
            if(mode == 1)
                for(int i=1;i<= _length;++i)
                {
                    Debug.Log(pointer.position.x.ToString()+" "+ pointer.position.y.ToString()+" " + pointer.position.y.ToString());
                    pointer = pointer._pre;
                }
            else if(mode==2)
            {
                for (int i = 0; i < _gamemanager.bin.transform.childCount; ++i)
                {
                    Destroy(_gamemanager.bin.transform.GetChild(i).gameObject);
                }

                for (int i = 1; i < _length; ++i)
                {
                    GameObject temp = Instantiate(_gamemanager.snakeBody) as GameObject;
                    temp.GetComponent<Transform>().position = pointer.position;
                    if(mode==2)
                        temp.GetComponent<Renderer>().material.color = Color.green;
                    temp.transform.parent = _gamemanager.bin.transform;
                    temp.name = i.ToString();
                    
                    temp.SetActive(true);
                    pointer = pointer._pre;
                }

                GameObject newGM = Instantiate(_gamemanager.snakeBody) as GameObject;
                newGM.GetComponent<Transform>().position = pointer.position;
                if (!ated)
                    newGM.GetComponent<Renderer>().material.color = Color.green;
                else
                    newGM.GetComponent<Renderer>().material.color = Color.blue;
                newGM.transform.parent = _gamemanager.bin.transform;
                newGM.name = /**/_length.ToString();

                newGM.SetActive(true);
                pointer = pointer._pre;
            }
            else if(mode==3)
            {
                for (int i = 0; i < _gamemanager.bin.transform.childCount; ++i)
                {
                    _gamemanager.bin.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
            }
        }
        
        public void CreateApple()
        {
            //gameObjApple.SetActive(false);
            for (int i = 0; i < _gamemanager.appleBin.transform.childCount; ++i)
            {
                Destroy(_gamemanager.appleBin.transform.GetChild(i).gameObject);
            }

            bool flag = true;

            while (flag)
            {
                _apple.x = (int)Random.Range(0, 7f);
                _apple.y = (int)Random.Range(0, 7f);
                _apple.z = (int)Random.Range(0, 7f);

                Node pointer = new Node(_head);

                for (int i = 1; i <= _length; ++i)
                {
                    //Debug.Log(pointer.position.x.ToString() + ;" " + pointer.position.y.ToString() + " " + pointer.position.y.ToString());
                    if (_apple==pointer.position)
                    {
                        flag = true;
                        break;//减少开销
                    }
                    else
                        flag = false;

                    pointer = pointer._pre;
                }
            }
            Debug.Log(_apple.x.ToString() + " " + _apple.y.ToString() + " " + _apple.z.ToString());

            //newGM.name = globalcount.ToString();
            //globalcount++;
            GameObject temp = Instantiate(_gamemanager.snakeBody);
            temp.GetComponent<Transform>().position = _apple;
            temp.GetComponent<Renderer>().material.color = Color.yellow;
            //
            temp.transform.parent = _gamemanager.appleBin.transform;
            temp.SetActive(true);
        }
        public bool IsEatingApple()
        {
            if(_head.position==_apple)
            {
                ated = true;
                return true;
            }
            else
            {
                ated = false;
                return false;
            }
        }
        public bool IsEatingSelf()
        {
            Node pointer = new Node(_head);
            Node checker = new Node(GetForwardNode());
            pointer = pointer._pre;
            
            for (int i = 1; i <= _length-1; ++i)
            {
                //Debug.Log(pointer.position.x.ToString() + " " + pointer.position.y.ToString() + " " + pointer.position.y.ToString());
                if (checker.position.x == pointer.position.x && checker.position.y == pointer.position.y && checker.position.z == pointer.position.z)
                    return true;
                pointer = pointer._pre;
            }
            return false;
        }

        public Node GetForwardNode()
        {
            switch (_destnation)
            {
                case 0://x+
                    return new Node(_head.position.x + 1, _head.position.y, _head.position.z, null, _head);

                case 1://z+
                    return new Node(_head.position.x , _head.position.y, _head.position.z+1, null, _head);

                case 2://z-
                    return new Node(_head.position.x , _head.position.y, _head.position.z-1, null, _head);

                case 3://y+
                    return new Node(_head.position.x , _head.position.y+1, _head.position.z, null, _head);

                case 4://y-
                    return new Node(_head.position.x , _head.position.y-1, _head.position.z, null, _head);

                case 5://x-
                    return new Node(_head.position.x - 1, _head.position.y, _head.position.z, null, _head);
                default:
                    return new Node();
            }
        }

        public void Move()
        {
            if (IsEatingSelf())
            {
                isdead = true;
            }
            else if (IsEatingWall() && _gamemanager.cageToggle.isOn)
            {
                isdead = true;
            }
            if (isdead)
            {
                return;
            }
            Node tempNode =_head._pre;
            tempNode = GetForwardNode();
            tempNode._pre = _head;
            _head._next = tempNode;
            _head = tempNode;
            if(!ated)
            {
                _tail = _tail._next;
                _tail._pre = null;
            }
            else
            {
                ++_length;
                ated = false;
            }
        }

        public bool IsEatingWall()
        {
            Node checker = new Node(GetForwardNode());
            if (checker.position.x >= 8 || checker.position.x < 0 ||
                checker.position.y >= 8 || checker.position.y < 0 ||
                checker.position.z >= 8 || checker.position.z < 0)
                return true;
            else
                return false;
        }

        public void ExDestnation(int x)
        {
            int before = _destnation;
            if (
            _destnation == 0 && x != 5||
            _destnation == 5 && x != 0 ||
            _destnation == 1 && x != 2 ||
            _destnation == 2 && x != 1 ||
            _destnation == 3 && x != 4 ||
            _destnation == 4 && x != 3 
            )
            {
                _destnation = x;
            }

            if (GetForwardNode().position == _head._pre.position)
            {
                _destnation = before;
            }
        }
        public int GetDestnation()
        {
            return _destnation;
        }

        private Vector3 visualHead = new Vector3();

        public Vector3 GetVisualHeadPosition()
        {
            return visualHead;
        }

        public int GetLength()
        {
            return _length;
        }

        public bool isdead = false;

        public bool isButtonDown;
        public bool needReCreate = false;

        private Vector3 _apple = new Vector3();
        public GameObject gameObjApple;

        private bool ated = false;

        private int _destnation;
        private Node nextNode;

        private readonly Gamemanager _gamemanager;
        
        private int _length;
        private Node _head = new Node(4,4,4);
        private Node _tail = new Node();
    }

    public Snake snake = new Snake();

    
    private bool cageFlag = false;
    // Start is called before the first frame update

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
    }
    void Start()
    {
        cageFlag = cageToggle.isOn;
        cage.SetActive(cageToggle.isOn);

        snake = new Snake(4, this);
        snake.PrintSnake(2);
    }


    // Update is called once per frame
    void Update()
    {
        textScore.text = "Your Score: " + (snake.GetLength()-4).ToString();
        //-----------------Score------------------------

        if (!paused)
        {
            breakText.text = "| |";
            if (scrollbar.value <= 0.04)
            {
                Time.timeScale = 0.04f;
            }
            else
            {
                Time.timeScale = scrollbar.value;
            }
        }
        else
        {
            breakText.text = "|>";
            Time.timeScale = 0f;
        }
        textSpeed.text = "Now TimeScale = " + Time.timeScale.ToString();
        
        //-----------------TimeScale------------------------

        if (snake.needReCreate)
        {
            snake = new Snake(4, this);
            snake.PrintSnake(2);
        }

        if (cageFlag!=cageToggle.isOn)
        {
            cageFlag = cageToggle.isOn;
            snake = new Snake(4, this);
            snake.PrintSnake(2);
        }
        cage.SetActive(cageToggle.isOn);

        //-----------------ReCreate------------------------

        if (Input.GetKey(KeyCode.W)      )
            snake.ExDestnation(1);
        else if (Input.GetKey(KeyCode.S) )
            snake.ExDestnation(2);
        else if (Input.GetKey(KeyCode.U) )
            snake.ExDestnation(3);
        else if (Input.GetKey(KeyCode.J) )
            snake.ExDestnation(4);
        else if (Input.GetKey(KeyCode.A) )
            snake.ExDestnation(5);
        else if (Input.GetKey(KeyCode.D) )
            snake.ExDestnation(0);
        else if(snake.isButtonDown)
        {

        }
        else
        {
            //allowMove = false;
        }

        //-----------------ChangeDestnation------------------------
        
        snake.isButtonDown = false;

        //-----------------ValueReset------------------------

        //Debug.Log(Time.deltaTime);
    }
}
