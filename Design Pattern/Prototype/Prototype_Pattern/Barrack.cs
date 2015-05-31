using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototype_Pattern
{
    class Barrack
    {
        public List<Unit> prototypes = new List<Unit>();
        public void InitAllUnits()
        {
            prototypes.Add(new Marine());
            prototypes[prototypes.Count-1].Init("Regular Marine", 10, 100, 50, 20);
            prototypes.Add(new Marine());
            prototypes[prototypes.Count - 1].Init("Veteran Marine", 10, 100, 50, 20);

            prototypes.Add(new Tank());
            prototypes[prototypes.Count - 1].Init("Tank", 1, 200, 500, 20);

            prototypes.Add(new Zealot());
            prototypes[prototypes.Count - 1].Init("Zealot", 5, 200, 500, 20);
        }
        internal Unit Recruit(int idx)
        {
            Unit unit = null;
            switch (idx)
            {
                case 0:
                    unit = new Marine();
                    break;
                case 1:
                    unit = new Tank();
                    break;
                case 2:
                    unit = new Zealot();
                    break;
            }
            if (idx >= 0 && idx < prototypes.Count)
            {
                return prototypes[idx].Clone();
            }
            return null;
        }

        public Unit Recruit(string name)
        {
            for (int i = 0; i < prototypes.Count; i++)
                if (prototypes[i].Name == name)
                    return Recruit(i);
            return null;
        }
    }
}

// Mẫu prototype cần:
// - Tạo sẵn các đối tượng đại diện các thực thể khác nhau ngoài đời.
// - Đôi khi ta có hàm Clone để nhân bản đối tượng (khi Clone kiểu trả về thì là kiểu tồng quát và khởi tạo đối tượng cùng loại).
// - Prototype có thể được sử dụng trực tiếp hoặc sữ dụng thông qua bản sao.
// - Tư tưởng: khó, không biết, không chắc chắn và có khả năng bị thay đổi thì giao nhiệm vụ nào cho một Component nào đó phụ trách.