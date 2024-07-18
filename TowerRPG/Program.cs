namespace TowerRPG
{
    internal class Program
    {
        enum Scene { FirstScene, GoldShop, TowerF1, TowerF2, TowerF3, TowerF4 }

        struct GameData
        {
            public bool running;

            public bool define;

            public bool goldshop;

            public Scene scene;

            public int maxHP;
            public int STR;
            public int DEF;
            public int gold;
        }

        struct MonsterData
        {
            public string name;
            public int maxHP;
            public int STR;
            public int DEF;
            public int gold;
        }

        static GameData data;

        static MonsterData GreenSlime, RedSlime, Bat, Skeleton, Boss;

        static void Main(string[] args)
        {
            Start();

            while (data.running)
            {
                Run();
            }

            End();
        }

        static void Start()
        {
            data = new GameData();

            data.running = true;

            data.define = false;

            data.goldshop = false;

            data.maxHP = 1000;
            data.STR = 10;
            data.DEF = 10;
            data.gold = 0;

            GreenSlime = new MonsterData();
            GreenSlime.name = "초록색 슬라임";
            GreenSlime.maxHP = 50;
            GreenSlime.STR = 20;
            GreenSlime.DEF = 1;
            GreenSlime.gold = 1;

            RedSlime = new MonsterData();
            RedSlime.name = "레드 슬라임";
            RedSlime.maxHP = 70;
            RedSlime.STR = 15;
            RedSlime.DEF = 2;
            RedSlime.gold = 2;

            Bat = new MonsterData();
            Bat.name = "박쥐";
            Bat.maxHP = 100;
            Bat.STR = 20;
            Bat.DEF = 5;
            Bat.gold = 3;

            Skeleton = new MonsterData();
            Skeleton.name = "해골";
            Skeleton.maxHP = 110;
            Skeleton.STR = 25;
            Skeleton.DEF = 5;
            Skeleton.gold = 4;

            Boss = new MonsterData();
            Boss.name = "마왕";
            Boss.maxHP = 1000;
            Boss.STR = 100;
            Boss.DEF = 100;
            Boss.gold = 1000;

            Console.Clear();

            Console.WriteLine("텍스트 RPG: 몬스터 타워");

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("계속하려면 아무키나 누르세요.");

            Console.ReadKey();
        }

        static void End()
        {
            Console.Clear();

            Console.WriteLine("게임 종료");

            Wait(1000);
        }

        static void Die(MonsterData Monster)
        {
            Console.Clear();

            Console.WriteLine($"당신은 {Monster.name}에게 죽었습니다.");

            Console.WriteLine();

            Console.WriteLine("게임 오버!");

            data.running = false;

            Wait(2);

        }

        static void Run()
        {
            Console.Clear();

            switch (data.scene)
            {
                case Scene.FirstScene:
                    FirstScene();
                    break;
                case Scene.GoldShop:
                    GoldShop();
                    break;
                case Scene.TowerF1:
                    TowerF1();
                    break;
                case Scene.TowerF2:
                    TowerF2();
                    break;
                case Scene.TowerF3:
                    TowerF3();
                    break;
                case Scene.TowerF4:
                    TowerF4();
                    break;
            }
        }

        static void Wait(float seconds)
        {
            Thread.Sleep((int)(seconds * 1000));
        }

        static void PrintProfile()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("이름 : 용사");
            Console.WriteLine($"체력 : {data.maxHP}");
            Console.WriteLine($"공격력 : {data.STR}");
            Console.WriteLine($"방어력 : {data.DEF}");
            Console.WriteLine($"소지금 : {data.gold} G");
            Console.WriteLine("=====================================");
            Console.WriteLine();
        }

        static void PrintMonsterProfile(MonsterData Monster)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine($"이름 : {Monster.name}");
            Console.WriteLine($"체력 : {Monster.maxHP}");
            Console.WriteLine($"공격력 : {Monster.STR}");
            Console.WriteLine($"방어력 : {Monster.DEF}");
            Console.WriteLine("=====================================");
            Console.WriteLine();
        }

        static void FirstScene()
        {
            Console.Clear();

            Console.WriteLine("용사님 공주가 마왕에게 납치 당했습니다.");

            Console.WriteLine("마왕은 몬스터 타워에 있습니다.");

            Console.WriteLine("구해주세요.");

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("행동을 선택하세요.");

            Console.WriteLine();

            Console.WriteLine("1. 구해준다.");

            Console.WriteLine("2. 구하지 않는다.");

            int SaveOrDieAnswer;

            while (true)
            {
                int.TryParse(Console.ReadLine(), out SaveOrDieAnswer);

                if (SaveOrDieAnswer == 1)
                {
                    Console.Clear();

                    Console.WriteLine("감사합니다.");

                    Console.WriteLine("몬스터와 싸우는 방법을 알려드릴게요.");

                    Console.WriteLine("몬스터와 조우 하면 용사님이 먼저 공격하면서 시작합니다.");

                    Console.WriteLine("용사님이 공격하신 후 몬스터가 공격합니다.");

                    Console.WriteLine("몬스터의 공격력보다 자신의 방어력이 높거나 같고,");

                    Console.WriteLine("몬스터의 방어력보다 자신의 공격력이 높을 경우는 전혀 데미지를 입지 않아요.");

                    Console.WriteLine("즉, 몬스터의 공격력이 10 / 방어력이 10일때 자신의 공격력이 11 / 방어력이 11일 경우입니다");

                    Console.WriteLine("주의하실 점은 몬스터의 방어력 보다 공격력이 낮으면 이길수가 없습니다.");

                    Console.WriteLine("설명은 이걸로 끝입니다. 몬스터 타워로 이동시켜 드릴게요.");

                    Console.WriteLine();

                    Console.WriteLine("계속하려면 아무키나 누르세요.");

                    Console.ReadKey();

                    break;
                }
                else if (SaveOrDieAnswer == 2)
                {
                    Console.Clear();

                    Console.WriteLine("당신은 공주를 죽였습니다.");

                    Console.WriteLine();

                    Console.WriteLine("게임 오버!");

                    data.running = false;

                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }

            data.scene = Scene.TowerF1;
        }

        static void Encounter(int floor, MonsterData Monster)
        {
            while (true)
            {
                Console.Clear();

                PrintProfile();

                Console.WriteLine();

                Console.WriteLine($"타워 {floor}층");

                Console.WriteLine();

                Console.WriteLine($"{Monster.name}와 조우했다!");

                Console.WriteLine();

                Console.WriteLine("행동을 선택하세요.");

                Console.WriteLine();

                Console.WriteLine("1. 싸운다.");

                Console.WriteLine("2. 조사한다.");

                if (data.goldshop == true)
                {
                    Console.WriteLine("3. 상점.");
                }

                int.TryParse(Console.ReadLine(), out int select);

                if (select == 1)
                {
                    Fight(Monster);

                    break;
                }
                else if (select == 2)
                {
                    Console.WriteLine();

                    PrintMonsterProfile(Monster);

                    Wait(2);
                }
                else if (select == 3)
                {
                    if (data.goldshop == true)
                    {
                        GoldShop();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");

                        Wait(2);
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");

                    Wait(2);
                }
            }
        }

        static void Findstairs(int floor)
        {
            Console.Clear();

            PrintProfile();

            Console.WriteLine();

            Console.WriteLine($"타워 {floor}층");

            Console.WriteLine();

            Console.WriteLine("계단을 발겼했다!");

            Console.WriteLine();

            Console.WriteLine("행동을 선택하세요.");

            Console.WriteLine();

            Console.WriteLine("1. 올라간다.");

            while (true)
            {
                int.TryParse(Console.ReadLine(), out int select);

                if (select == 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        static void ItemFound(string Item, int floor)
        {
            Console.Clear();

            PrintProfile();

            Console.WriteLine();

            Console.WriteLine($"타워 {floor}층");

            Console.WriteLine();

            Console.WriteLine($"{Item}을 발견했다!");

            Console.WriteLine();

            if (Item == "평범한 검")
            {
                data.STR += 10;
                Console.WriteLine("공격력이 10 상승했다!");
            }
            else if (Item == "빨간 보석")
            {
                data.STR += 3;
                Console.WriteLine("공격력이 3 상승했다!");
            }
            else if (Item == "파란 보석")
            {
                data.DEF += 3;
                Console.WriteLine("방어력이 3 상승했다!");
            }
            else if (Item == "중급 포션")
            {
                data.maxHP += 500;
                Console.WriteLine("체력을 500 회복 했다!");
            }
            else
            {
                Console.WriteLine("에러 아이템 명을 확인해주세요.");
                Console.ReadLine();
            }

            Wait(2);

            Console.WriteLine();

            Console.WriteLine("계속하려면 아무키나 누르세요.");

            Console.ReadKey();

        }

        static void GoldShopFound()
        {
            Console.Clear();

            PrintProfile();

            Console.WriteLine();

            Console.WriteLine("상점을 발견했다!");

            Console.WriteLine();

            data.goldshop = true;

            Console.WriteLine("행동에 상점이 추가되었다!");

            Console.WriteLine();

            Wait(2);

            Console.WriteLine("계속하려면 아무키나 누르세요.");

            Console.ReadKey();

        }

        static void GoldShop()
        {
            while (true)
            {
                Console.Clear();

                PrintProfile();

                Console.WriteLine();

                Console.WriteLine($"상점 입니다. 모든 상품은 25G 입니다.");

                Console.WriteLine();

                Console.WriteLine("상품을 선택하세요.");

                Console.WriteLine();

                Console.WriteLine("1. 체력을 800 회복한다.");

                Console.WriteLine("2. 공격력을 4 구매한다.");

                Console.WriteLine("3. 방어력을 4 구매한다.");

                Console.WriteLine("4. 돌아간다.");

                int.TryParse(Console.ReadLine(), out int select);

                if (select == 1)
                {
                    if (data.gold >= 25)
                    {
                        data.maxHP += 800;

                        data.gold -= 25;

                        Console.WriteLine("체력을 800 회복했다!");

                        Wait(2);

                    }
                    else
                    {
                        Console.WriteLine("돈이 부족합니다.");

                        Wait(2);
                    }
                }
                else if (select == 2)
                {
                    if (data.gold >= 25)
                    {
                        data.STR += 4;

                        data.gold -= 25;

                        Console.WriteLine("공격력이 4 상승했다!");

                        Wait(2);
                    }
                    else
                    {
                        Console.WriteLine("돈이 부족합니다.");

                        Wait(2);
                    }
                }
                else if (select == 3)
                {
                    if (data.gold >= 25)
                    {
                        data.DEF += 4;

                        data.gold -= 25;

                        Console.WriteLine("방어력이 4 상승했다!");

                        Wait(2);
                    }
                    else
                    {
                        Console.WriteLine("돈이 부족합니다.");

                        Wait(2);
                    }
                }
                else if (select == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");

                    Wait(2);
                }
            }
        }

        static void Fight(MonsterData Monster)
        {
            while (true)
            {
                Console.Clear();

                PrintProfile();

                Console.WriteLine();

                Console.WriteLine($"{Monster.name}을 공격했다!");

                Monster.maxHP = Monster.maxHP - (data.STR - Monster.DEF);

                Console.WriteLine($"{data.STR - Monster.DEF}의 피해를 입혔다.");

                Console.WriteLine();

                Console.WriteLine();

                if (Monster.maxHP <= 0)
                {
                    Console.Clear();

                    PrintProfile();

                    Console.WriteLine();

                    Console.WriteLine($"{Monster.name}이 죽었습니다.");

                    Console.WriteLine();

                    data.gold = data.gold + Monster.gold;

                    Console.WriteLine($"{Monster.gold} 골드를 얻었습니다.");

                    Console.WriteLine();

                    Console.WriteLine("계속하려면 아무키나 누르세요.");

                    Console.ReadKey();

                    break;
                }

                PrintMonsterProfile(Monster);

                Console.WriteLine("계속하려면 아무키나 누르세요.");

                Console.ReadKey();

                Console.Clear();

                PrintProfile();

                Console.WriteLine();

                Console.WriteLine($"{Monster.name}이 공격했다!");

                data.maxHP = data.maxHP - (Monster.STR - data.DEF);

                Console.WriteLine($"{Monster.STR - data.DEF}의 피해를 입었다.");

                Console.WriteLine();

                Console.WriteLine();

                if (data.maxHP <= 0)
                {
                    Die(Monster);

                    End();

                    break;
                }

                PrintProfile();

                Console.WriteLine("계속하려면 아무키나 누르세요.");

                Console.ReadKey();
            }
        }

        static void TowerF1()
        {
            int floor = 1;

            Encounter(floor, GreenSlime);

            Encounter(floor, RedSlime);

            Encounter(floor, GreenSlime);

            Findstairs(floor);

            data.scene = Scene.TowerF2;
        }

        static void TowerF2()
        {
            int floor = 2;

            Encounter(floor, Bat);

            Encounter(floor, GreenSlime);

            Encounter(floor, GreenSlime);

            Encounter(floor, Skeleton);

            Encounter(floor, RedSlime);

            ItemFound("평범한 검", floor);

            Encounter(floor, Bat);

            Encounter(floor, RedSlime);

            Encounter(floor, Bat);

            Encounter(floor, RedSlime);

            ItemFound("파란 보석", floor);

            ItemFound("빨간 보석", floor);

            ItemFound("중급 포션", floor);

            Encounter(floor, Skeleton);

            GoldShopFound();

            Encounter(floor, Bat);

            Encounter(floor, RedSlime);

            Findstairs(floor);

            data.scene = Scene.TowerF3;

        }

        static void TowerF3()
        {
            int floor = 3;

            Console.Clear();

            PrintProfile();

            Console.WriteLine();

            Console.WriteLine($"타워 {floor}층");

            Console.WriteLine();

            Console.WriteLine("용사님 다음 층에 마왕이 있습니다.");

            Console.WriteLine("여기에서 지금까지 싸웠던 몬스터들과 원하는 만큼 싸울 수 있습니다.");

            Console.WriteLine("준비가 끝나면 올라가 주세요.");

            Wait(5);

            while (true)
            {
                Console.Clear();

                PrintProfile();

                Console.WriteLine();

                Console.WriteLine("행동을 선택하세요.");

                Console.WriteLine();

                Console.WriteLine("1. 싸운다.");

                Console.WriteLine("2. 다음 층으로.");

                if (data.goldshop == true)
                {
                    Console.WriteLine("3. 상점.");
                }

                int.TryParse(Console.ReadLine(), out int select);

                if (select == 1)
                {
                    Console.Clear();

                    PrintProfile();

                    Console.WriteLine();

                    Console.WriteLine("전투할 몬스터를 선택하세요.");

                    Console.WriteLine();

                    Console.WriteLine("1. 초록 슬라임");

                    Console.WriteLine("2. 빨간 슬라임");

                    Console.WriteLine("3. 박쥐");

                    Console.WriteLine("4. 해골.");

                    Console.WriteLine();

                    int.TryParse(Console.ReadLine(), out int selectMon);

                    if (selectMon == 1)
                    {
                        Fight(GreenSlime);
                    }
                    else if (selectMon == 2)
                    {
                        Fight(RedSlime);
                    }
                    else if (selectMon == 3)
                    {
                        Fight(Bat);
                    }
                    else if (selectMon == 4)
                    {
                        Fight(Skeleton);
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");

                        Wait(2);
                    }
                }
                else if (select == 2)
                {
                    break;
                }
                else if (select == 3)
                {
                    if (data.goldshop == true)
                    {
                        GoldShop();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");

                        Wait(2);
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");

                    Wait(2);
                }
            }

            data.scene = Scene.TowerF4;
        }

        static void TowerF4()
        {
            int floor = 4;

            Console.Clear();

            PrintProfile();

            Console.WriteLine();

            Console.WriteLine($"타워 {floor}층");

            Console.WriteLine();

            Console.WriteLine("여기까지 잘 왔다 용사여");

            Wait(1);
            Console.WriteLine(".");

            Wait(1);
            Console.WriteLine(".");

            Wait(1);
            Console.WriteLine(".");

            Console.WriteLine("날 이기면 공주를 풀어주지");

            Wait(1);
            Console.WriteLine(".");

            Wait(1);
            Console.WriteLine(".");

            Wait(1);
            Console.WriteLine(".");

            Fight(Boss);

            Console.Clear();

            Console.WriteLine("감사합니다. 용사님");

            Console.WriteLine();

            Console.WriteLine("마왕을 죽이고 공주를 구했습니다.");

            Console.WriteLine();

            Console.WriteLine("끝");

            Console.ReadKey();

            data.running = false;
        }
    }
}
