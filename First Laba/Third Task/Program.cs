using Third_Task;

TreeNode root = new TreeNode("Root");

TreeNode child1 = new TreeNode("Child 1");
TreeNode child2 = new TreeNode("Child 2");
TreeNode child3 = new TreeNode("Child 3");

root.AddChild(child1);
root.AddChild(child2);

TreeNode grandChild1 = new TreeNode("Grandchild 1");
TreeNode grandChild2 = new TreeNode("Grandchild 2");
child1.AddChild(grandChild1);
child1.AddChild(grandChild2);

TreeNode grandChild3 = new TreeNode("Grandchild 3");
child2.AddChild(grandChild3);

Console.WriteLine("Tree structure:");
root.PrintChildren();