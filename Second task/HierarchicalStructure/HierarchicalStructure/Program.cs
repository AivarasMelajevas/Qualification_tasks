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
            Branch structure = new Branch
            {
                branches = new List<Branch>()
            {
                new Branch
                {
                    branches = new List<Branch>
                    {
                        new Branch
                        {
                            branches = new List<Branch>()
                        }
                    }
                },
                new Branch
                {
                    branches = new List<Branch>
                    {
                        new Branch
                        {
                            branches = new List<Branch>
                            {
                                new Branch
                                {
                                    branches = new List<Branch>()
                                }
                            }
                        },
                        new Branch
                        {
                            branches = new List<Branch>
                            {
                                new Branch
                                {
                                    branches = new List<Branch>
                                    {
                                        new Branch
                                        {
                                            branches = new List<Branch>()
                                        }
                                    }
                                },
                                new Branch
                                {
                                    branches = new List<Branch>()
                                }
                            }
                        },
                        new Branch
                        {
                            branches = new List<Branch>()
                        }
                    }
                },
            }
            };

            return structure;
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
