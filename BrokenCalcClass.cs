public class Solution {
    // TC => O(log n) n is the value of target
    // SC => O(1)
    public int BrokenCalc(int startValue, int target) {
        if(startValue > target){
            return startValue - target;
        }

        int count = 0;
        while(target > startValue){
            if(target % 2 == 0){
                target /= 2;
            }
            else{
                target += 1;
            }
            count++;
        }
        return count + (startValue - target);
    }
    
    // TC => O(2^n)
    // SC => O(H)
    public int BrokenCalc1(int startValue, int target) {
        if(startValue > target){
            return startValue - target;
        }

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(startValue);
        int level = 0;

        while(queue.Count > 0){
            int size = queue.Count;
            for(int i = 0; i< size; i++){
                int current = queue.Dequeue();
                if(current == target){
                    return level;
                }

                if(current > target){
                    queue.Enqueue(current - 1);
                }
                else{
                    queue.Enqueue(current - 1);
                    queue.Enqueue(current * 2);
                }
                
            }
            level++;
        }

        return 0;
    }
}