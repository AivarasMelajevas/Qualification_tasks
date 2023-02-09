namespace HierarchicalStructure
{
    public class Program
    {
        static void Main()
        {
            Branch structure = CreateStructure();

            Console.WriteLine("The depth of the structure is: " + CalculateDepth(structure));
        }
        static Branch CreateStructure()
        {
            Branch root = new Branch();

            Branch firstGenChild1 = new Branch();
            Branch firstGenChild2 = new Branch();
            root.branches.Add(firstGenChild1);
            root.branches.Add(firstGenChild2);

            Branch secondGenChild1 = new Branch();
            Branch secondGenChild2 = new Branch();
            Branch secondGenChild3 = new Branch();
            Branch secondGenChild4 = new Branch();
            firstGenChild1.branches.Add(secondGenChild1);
            firstGenChild2.branches.Add(secondGenChild2);
            firstGenChild2.branches.Add(secondGenChild3);
            firstGenChild2.branches.Add(secondGenChild4);

            Branch thirdGenChild1 = new Branch();
            Branch thirdGenChild2 = new Branch();
            Branch thirdGenChild3 = new Branch();
            secondGenChild2.branches.Add(thirdGenChild1);
            secondGenChild3.branches.Add(thirdGenChild2);
            secondGenChild3.branches.Add(thirdGenChild3);

            Branch fourthGenChild1 = new Branch();
            thirdGenChild2.branches.Add(fourthGenChild1);

            return root;
        }

        static int CalculateDepth(Branch branch)
        {
            if (branch == null)
            {
                return 0;
            }

            int maxDepth = 0;
            foreach (Branch child in branch.branches)
            {
                int childDepth = CalculateDepth(child);
                if (childDepth > maxDepth)
                {
                    maxDepth = childDepth;
                }
            }

            return maxDepth + 1;
        }

    }
}
