﻿using System.Collections.Generic;

namespace FirstApp
{
    class TreeNode : BaseClass
    {
        private List<TreeNode> Children { get; set; }
        private TreeNode Father { get; set; }
        private string Name { get; set; }
        public TreeNode(TreeNode Parrent, string name)
        {
            this.Father = Parrent;
            this.Name = name;
            this.Children = new List<TreeNode>();
            this.Content = "";
            this.Attributes = new Dictionary<string, string>();
        }
        public void AddChildren(TreeNode Child)
        {
            this.Children.Add(Child);
        }
        public void SetFather(TreeNode Parrent)
        {
            this.Father = Parrent;
        }

        public TreeNode GetFather()
        {
            return this.Father;
        }

        public void PrintName()
        {
            System.Console.Write(this.Name);
        }
    }
}