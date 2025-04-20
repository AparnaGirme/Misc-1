/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    // TC => O(n)
    // SC => O(h)
    int moves = 0;
    public int DistributeCoins(TreeNode root) {
        if(root == null){
            return 0;
        }

        Dfs(root);
        return moves;
    }

    public int Dfs(TreeNode root){
        // base
        if(root == null){
            return 0;
        }
        // logic
        int extra = root.val - 1;
        extra += Dfs(root.left);
        extra += Dfs(root.right);

        moves += Math.Abs(extra);
        return extra;
    }
}