---
title: Rewards System 
weight: 1
---

# Rewards System

### Ways to Earn Rewards

There are three ways for users to earn rewards:

1. **Daily Consecutive Login Rewards**: Users receive rewards for logging in consecutively each day. Missing a day resets the consecutive login count in Firebase Firestore. The rewards for each day are:
    - Day 1: 25 experience points (exp) and shopping points
    - Day 2: A random font color
    - Day 3: 50 exp and shopping points
    - Day 4: A random background color
    - Day 5: 100 exp and shopping points
    - Day 6: 1-day exp multiplier
    - Day 7: 50 cheer coins

2. **Daily Mission Rewards**: There are 7 daily missions (tasks) that users can complete to earn exp points and shopping points. Each mission offers different rewards and points. It's important to collect points promptly after completing each mission, as points do not accumulate if not collected. The missions include:
    - Comment once in chat
    - Watch a live-stream 
    - Follow a streamer
    - Send a gift to a streamer
    - Share the app
    - Start a live-stream
    - Purchase cheer coins

3. **Level Rewards**: Users automatically level up when they accumulate enough points. The rewards for reaching specific levels are:
    - Level 2: Option to hide or show the level logo in chat
    - Level 5: A random item from the item shop
    - Level 10: Exp multiplier for 3 days
    - Level 15: A random UI skin
    - Level 20: A random font style
    - Level 25: A random emoji package
    - Level 30: A random animated emoji package


### Daily Consecutive Login 

In our application, consecutive login tracking is a crucial feature handled by the following components:

1. **FirebaseUserInfoViewModel.swift**: This module manages user information within Firebase, including handling consecutive login updates.
   
2. **Cheer_SupportsApp.swift Task**: The startup task responsible for initializing app components.


#### Update Daily Login and Consecutive Login Logic

The following functions illustrate how the application updates the consecutive login count based on user activities:

```swift
// Update consecutive login count based on last login date comparison
func updateDailyLogin() {
    guard let uid = FirebaseManager.shared.auth.currentUser?.uid else { return }

    // Retrieve last login date from Firebase
    getUserData(parameterName: UserInfoConstants.lastLogin) { [self] value in
        let lastLoginDate = (value as AnyObject).dateValue()

        let calendar = NSCalendar.autoupdatingCurrent

        // Compare last login with today's date
        if calendar.isDateInYesterday(lastLoginDate) {
            updateConsecutiveLogin(increment: 1)
        } else if !calendar.isDateInToday(lastLoginDate) {
            updateConsecutiveLogin(increment: 0)
        }

        // Update last login date in Firebase
        FirebaseManager.shared.firestore
            .collection(FirebaseCollectionConstants.users)
            .document(uid)
            .updateData([UserInfoConstants.lastLogin: Date.now]) { error in
                if let error = error {
                    print("Error updating last login date: \(error.localizedDescription)")
                }
            }
    }
}

// Update consecutive login count in Firebase
func updateConsecutiveLogin(increment: Int) {
    guard let uid = FirebaseManager.shared.auth.currentUser?.uid else { return }

    FirebaseManager.shared.firestore
        .collection(FirebaseCollectionConstants.users)
        .document(uid)
        .updateData([UserInfoConstants.consecutiveLogin: increment == 1 ? FieldValue.increment(Int64(1)) : 0]) { error in
            if let error = error {
                print("Error updating consecutive login count: \(error.localizedDescription)")
                return
            }
            print("Consecutive login count updated successfully.")
        }
}
```

#### Rewards System Integration

Based on the consecutive login count, users receive rewards, all related functions are in `MissionPage.swift`:

```swift
let userInfoVM = FirebaseUserViewModel()

.task {
    Task {
        envManager.retrieveData()
        if !envManager.email.isEmpty {
            let auth = try await loginVM.authenticate(email: envManager.email, password: envManager.password)
            .
            .
            .
            // Collect daily login reward based on consecutive login count
            switch userInfoVM.cons_login_value {
            case 0:
                loginRewardDay1()
            case 1:
                loginRewardDay2()
            case 2:
                loginRewardDay3()
            case 3:
                loginRewardDay4()
            case 4:
                loginRewardDay5()
            case 5:
                loginRewardDay6()
            case 6:
                loginRewardDay7()
            default:
                print("Error: Consecutive login count exceeds limit.")
            }
        }
    }
}
```

#### Reset Consecutive Login Count

When the user logs in consecutively for 7 days, the application resets the consecutive login count:

```swift
// Reset consecutive login count if it exceeds 6
func resetConsecutiveLogin() {
    getUserData(parameterName: UserInfoConstants.consecutiveLogin) { value in
        let consecutiveLogin = value as! Int

        guard let uid = FirebaseManager.shared.auth.currentUser?.uid else { return }

        if consecutiveLogin > 6 {
            FirebaseManager.shared.firestore
                .collection(FirebaseCollectionConstants.users)
                .document(uid)
                .updateData([UserInfoConstants.consecutiveLogin: 0]) { error in
                    if let error = error {
                        print("Error resetting consecutive login count: \(error.localizedDescription)")
                        return
                    }
                    print("Consecutive login count reset successfully.")
                }
        } else {
            print("No need to reset consecutive login count.")
        }
    }
}
```

Consecutive login tracking not only enhances user engagement but also drives user retention through a structured rewards system. These functionalities are crucial for maintaining user interest and loyalty in our application.


### Daily Mission

This feature enables users to accumulate shopping points within the app, which can then be used to purchase items.

**Daily Task Management**

The daily task management is handled in `MissionPage.swift`. Initially, all buttons related to tasks are inactive and reset daily. Users can collect rewards once a day upon completing the tasks. 

**Reward Collection Mechanism**

Rewards are managed through the `MissionRewards` array in the Firebase Database, located under the `User` collection. This array tracks daily collections and ensures users can claim rewards once per day if tasks are completed.


The shopping points collection system enhances user engagement by providing incentives for completing daily tasks. By utilizing Firebase for storing and managing rewards, the system ensures a seamless and rewarding user experience.

#### Activation of 'Collect' Button Upon Task Completion

Button activation is managed through the Observable object `MissionViewModel.swift`, specifically using the public variable `disabledButton`, which is an array (`Array<Bool>`).

Upon completing a task, the respective button is automatically activated. The following details how each task completion corresponds to button activation within the script:

- `disabledButton[0]`: Activates the "Send a message" mission button in the Global Chat View.
- `disabledButton[1]`: Activates the "Watch livestream" mission button in the Content View within the `.task` function of the view.
- `disabledButton[2]`: Activates the "Follow a streamer" mission button in the Profile Page View. It checks the user's follower count when the URL changes and sets the initial value.
- `disabledButton[3]`: Activates the "Send a gift" mission button in the Content View.
- `disabledButton[4]`: Activates the "Share the app" mission button in the Settings Menu.
- `disabledButton[5]`: Activates the "Start live stream" mission button in the Content View.
- `disabledButton[6]`: Activates the "Purchase Cheer Coin" mission button in the CheerItemPurchase view.


This mechanism ensures that users can easily collect their rewards once they have completed the required missions.



### Level Rewards
