using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Third_Task
{
    public class TreeNode
    {
        public string Value { get; set; }

        public List<TreeNode> Children { get; set; }

        public TreeNode(string value)
        {
            Value = value;
            Children = new List<TreeNode>();
        }

        public void AddChild(TreeNode child)
        {
            Children.Add(child);
        }

        public void PrintChildren()
        {
            Console.WriteLine(Value);

            if (Children.Count > 0)
            {
                foreach (var child in Children)
                {
                    child.PrintChildren();
                }
            }
        }
    }
}
