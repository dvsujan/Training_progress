class Solution:
    def threeSumClosest(self, nums: List[int], target: int) -> int:
        if len(nums) < 3:
            return 0
        
        nums.sort()
        min_distance = float('inf')
        closest_sum = float('-inf')
        
        for start in range(len(nums) - 2):
            left = start + 1
            right = len(nums) - 1
            
            while left < right:
                curr_sum = nums[start] + nums[left] + nums[right]
                
                if curr_sum == target:
                    return target
                
                if curr_sum < target:
                    left += 1
                else:
                    right -= 1
                
                if abs(curr_sum - target) < min_distance:
                    closest_sum = curr_sum
                    min_distance = abs(curr_sum - target)
        
        return closest_sum