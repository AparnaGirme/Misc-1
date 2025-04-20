/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // Constructor initializes an empty nested list.
 *     public NestedInteger();
 *
 *     // Constructor initializes a single integer.
 *     public NestedInteger(int value);
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // The result is undefined if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // Set this NestedInteger to hold a single integer.
 *     public void SetInteger(int value);
 *
 *     // Set this NestedInteger to hold a nested list and adds a nested integer to it.
 *     public void Add(NestedInteger ni);
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // The result is undefined if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class Solution {
    int sum = 0;
    public int DepthSum(IList<NestedInteger> nestedList) {
        if(nestedList == null || nestedList.Count == 0){
            return 0;
        }
        Bfs1(nestedList, 1);
        // Dfs(nestedList, 1);
        return sum;
    }

     public void Bfs1(IList<NestedInteger> nestedList, int level){
        Queue<IList<NestedInteger>> queue = new Queue<IList<NestedInteger>>();
        queue.Enqueue(nestedList);

        while(queue.Count > 0){
            int size = queue.Count;
            for(int i = 0; i< size; i++){
                IList<NestedInteger> current = queue.Dequeue();
                foreach(var nl in current){
                    if(nl.IsInteger()){
                        sum += nl.GetInteger() * level;
                    }
                    else{
                        queue.Enqueue(nl.GetList());
                    }
                
                }
            }
            level++;
        }
    }
    // TC => O(N)
    // SC => O(N)
    public void Bfs(IList<NestedInteger> nestedList, int level){
        Queue<NestedInteger> queue = new Queue<NestedInteger>();
        foreach(var nl in nestedList){
            queue.Enqueue(nl);
        }

        while(queue.Count > 0){
            int size = queue.Count;
            for(int i = 0; i< size; i++){
                NestedInteger current = queue.Dequeue();
                if(current.IsInteger()){
                    sum += current.GetInteger() * level;
                }
                else{
                    foreach(var nl1 in current.GetList()){
                        queue.Enqueue(nl1);
                    }
                }
            }
            level++;
        }
    }

    // TC => O(N)
    // SC => O(H)
    public void Dfs(IList<NestedInteger> nestedList, int level){
        foreach(var nl in nestedList){
            if(nl.IsInteger()){
                sum += nl.GetInteger() * level;
            }
            else{
                Dfs(nl.GetList(), level + 1);
            }
        }
    }
}