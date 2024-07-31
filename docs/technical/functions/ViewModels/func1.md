---
title: "Firebase User Info"
weight: 0
---

# FirebaseUserInfoViewModel: Firebase Operations

## Overview

The `FirebaseUserInfoViewModel` class handles user information management using Firebase. It provides functionalities for user authentication, account creation, data retrieval, and deletion. It interacts with Firebase Authentication and Firestore to manage user data and user sessions.

## Properties

- `@Published var currentExp: Int = 0`
- `@Published var levelCap: Int = 200`
- `@Published var levelLogo: String = ""`
- `@Published var userLevel: Int = 1`
- `@Published var shopPoint: Int = 0`
- `@Published var cons_login_value: Int = 0`
- `@Published var collectMissionRewards: [Bool] = [true,true,true,true,true,true,true]`
- `@Published var collectDailyLoginRewards: Bool = false`
- `@Published var boosterExpirationDate = Date.now`
- `@Published var lockLevelLabelToggle = true`
- `@Published var expMultiplier = 1`

## Methods

### AUTHORIZATION FUNCTIONS

#### Check User ID 
```swift
checkUser(userId: String, completion: @escaping (Bool) -> Void)
```

Checks if a user exists in the Firestore database based on the provided user ID.

**Parameters:**

- `userId`: The user ID to search for in the database.
- `completion`: A closure that receives a boolean indicating whether the user exists.

**Details:**

- Queries the Firestore `users` collection.
- Searches for documents where the field `userID` matches the provided `userId`.
- Calls `completion(true)` if a matching document is found, otherwise `completion(false)`.

#### Create New User 
```swift
firebaseCreateUser_Login(email: String, password: String, userID: String)
```

Creates a new user with specified email and password, and initializes user data in Firestore.

**Parameters:**

- `email`: The email address for the new user.
- `password`: The password for the new user.
- `userID`: The unique identifier for the new user.

**Details:**

- Creates a new user using Firebase Authentication.
- Calls `saveUserInformation` to store the user's initial data in Firestore.

#### SignIn the Firebase  
```swift
firebaseSignIn(email: String, password: String)
```

Signs in a user with specified email and password.

**Parameters:**

- `email`: The email address for sign-in.
- `password`: The password for sign-in.

**Details:**

- Signs in the user using Firebase Authentication.
- Updates the daily login date and resets the consecutive login counter.

#### Withdraw the Account 
```swift
deleteFirebaseAccount() async
```


Deletes the current user's Firebase account and associated Firestore document.

**Details:**

- Deletes the user account if the user is authenticated.
- Deletes the user's document from the Firestore `users` collection.

### SAVE THE NEW USER

#### Method: 

```swift
saveUserInformation(
    userID: String, 
    shopPoint: Int, 
    totalExp: Int, 
    consecutiveLogin: Int, 
    totalLogin: Int, 
    level: Int, 
    ownedItems: [String], 
    expBoosterEndDay: Date, 
    lastLogin: Date, 
    dailyReward: Bool, 
    missionRewards: [Bool], 
    blockedUsers: [String], 
    invisibleMsgs: [String], 
    fcmToken: String
)

```

Saves new user information to Firestore.

**Parameters:**

- `userID`: The unique identifier for the user.
- `shopPoint`: The initial shop points for the user.
- `totalExp`: The initial experience points for the user.
- `consecutiveLogin`: The initial value of consecutive logins.
- `totalLogin`: The initial total login count.
- `level`: The initial user level.
- `ownedItems`: A list of items owned by the user.
- `expBoosterEndDay`: The end date for the experience booster.
- `lastLogin`: The last login date.
- `dailyReward`: Indicates if the daily reward has been collected.
- `missionRewards`: A list of boolean values indicating mission rewards status.
- `blockedUsers`: A list of blocked user IDs.
- `invisibleMsgs`: A list of hidden message IDs.
- `fcmToken`: The FCM token for notifications.

**Details:**

- Constructs a dictionary with user data.
- Saves the dictionary to Firestore in the `users` collection.


### UPDATE SERVER VALUES

#### FCM Token
```swift
updateFCMToken(fcmToken: String) async
```

Updates the Firebase Cloud Messaging (FCM) token for the current user in Firestore.

**Parameters:**

- `fcmToken`: The new FCM token to be updated for the user.

**Details:**

- Retrieves the current user's UID.
- Attempts to update the FCM token in Firestore under the `fcmToken` field.
- Handles errors by printing the error message if the update fails.

#### Exp Booster  
```swift
updateExpBooster(dayIncrease: Int)
```

Updates the `expBoosterEndDay` value in Firestore based on the given number of days to increase.

**Parameters:**

- `dayIncrease`: The number of days to add to the current expiration date.

**Details:**

- Retrieves the current user's UID.
- Fetches the existing expiration date of the experience booster from Firestore.
- Calculates the new expiration date by adding the specified number of days.
- Updates the `expBoosterEndDay` field in Firestore with the new expiration date.
- Handles errors by printing an error message if the update fails.

#### Owned Item List
```swift
 updateOwnedItemsList(item: String)
```

Adds a new item to the user's list of owned items in Firestore.

**Parameters:**

- `item`: The item to be added to the owned items list.

**Details:**

- Retrieves the current user's UID.
- Fetches the current list of owned items from Firestore.
- Adds the new item to the list if it is not already present.
- Updates the `ownedItems` field in Firestore with the new list of owned items.
- Handles errors by printing an error message if the update fails.

#### Level Up 
```swift
updateLevel()
```

Updates the user's level, logo, and experience points based on the current level and experience.

**Details:**

- Retrieves the current user's UID.
- Fetches the current user level and experience points from Firestore.
- Checks if the experience points exceed the current level cap.
- If so, increments the user level, resets the experience points, and updates the level and logo information.
- Updates the user's level and experience points in Firestore.
- Fetches and updates the new level logo.
- Handles errors by printing appropriate messages if any operations fail.

#### Exp Point
```swift
updateExpPoint(addExpPoint: Int)
```

Increases the user's total experience points in Firestore.

**Parameters:**

- `addExpPoint`: The number of experience points to add.

**Details:**

- Retrieves the current user's UID.
- Updates the `totalExp` field in Firestore by incrementing it with the specified number of experience points.
- Handles errors by printing an error message if the update fails.

#### Shop Point 
```swift
updateShopPoints(newShopPoint: Int)
```

Updates the user's shop points in Firestore.

**Parameters:**

- `newShopPoint`: The amount to increment the shop points.

**Details:**

- Retrieves the current user's UID.
- Updates the `shopPoint` field in Firestore by incrementing it with the specified amount.
- Fetches the updated shop points from Firestore and updates the local `shopPoint` property.
- Handles errors by printing an error message if the update fails.

#### Login Date
```swift
updateDailyLogin()
```

Updates the last login date and manages consecutive login and daily rewards based on the last login date.

**Details:**

- Retrieves the current user's UID.
- Fetches the last login date from Firestore.
- Compares the last login date with the current date to determine if the login is consecutive or not.
- Updates consecutive login count, daily rewards, and mission rewards accordingly.
- Updates the `lastLogin` field in Firestore with the current date.
- Handles errors by printing an error message if the update fails.

#### Missions Reward Collected Status
```swift
updateMissionRewards(newArray: Array<Bool>)
```

Updates the status of mission rewards in Firestore.

**Parameters:**

- `newArray`: An array of boolean values representing the status of mission rewards.

**Details:**

- Retrieves the current user's UID.
- Updates the `missionRewards` field in Firestore with the new array of reward statuses.
- Handles errors by printing an error message if the update fails.

#### Daily Reward Collected Status
```swift
updateDailyRewards(value: Bool)
```

Updates the daily reward status for the user in Firestore.

**Parameters:**

- `value`: A boolean indicating whether the daily reward has been collected.

**Details:**

- Retrieves the current user's UID.
- Updates the `dailyReward` field in Firestore with the specified value.
- Handles errors by printing an error message if the update fails.

#### Consecutive Login
```swift
updateConsecutiveLogin(increment: Int)
```

Updates the consecutive login count in Firestore based on the provided increment value.

**Parameters:**

- `increment`: The value to increment the consecutive login count (usually 1).

**Details:**

- Retrieves the current user's UID.
- Updates the `consecutiveLogin` field in Firestore by incrementing it with the specified value or resetting it.
- Fetches and updates the local `cons_login_value` property.
- Handles errors by printing an error message if the update fails.

#### Blocked User List - Add
```swift
addBlockedUserList(uuid: String)
```

Adds a user ID to the blocked users list in Firestore.

**Parameters:**

- `uuid`: The user ID to be added to the blocked users list.

**Details:**

- Retrieves the current user's UID.
- Fetches the current list of blocked users from Firestore.
- Adds the new user ID to the list if it is not already present.
- Updates the `blockedUsers` field in Firestore with the new list.
- Handles errors by printing an error message if the update fails.

#### Blocked User List - Remove
```swift
removeBlockedUserList(uuid: String)
```

Removes a user ID from the blocked users list in Firestore.

**Parameters:**

- `uuid`: The user ID to be removed from the blocked users list.

**Details:**

- Retrieves the current user's UID.
- Fetches the current list of blocked users from Firestore.
- Removes the user ID from the list if it is present.
- Updates the `blockedUsers` field in Firestore with the updated list.
- Handles errors by printing an error message if the update fails.

#### Hidden Message List - Add
```swift
addHiddenChatList(uuid: String)
```

Adds a user ID to the hidden messages list in Firestore.

**Parameters:**

- `uuid`: The user ID to be added to the hidden messages list.

**Details:**

- Retrieves the current user's UID.
- Fetches the current list of hidden messages from Firestore.
- Adds the new user ID to the list if it is not already present.
- Updates the `hiddenMsgs` field in Firestore with the new list.
- Handles errors by printing an error message if the update fails.

#### Hidden Message List - Remove
```swift
removeHiddenChatList(uuid: String)
```

Removes a user ID from the hidden messages list in Firestore.

**Parameters:**

- `uuid`: The user ID to be removed from the hidden messages list.

**Details:**

- Retrieves the current user's UID.
- Fetches the current list of hidden messages from Firestore.
- Removes the user ID from the list if it is present.
- Updates the `hiddenMsgs` field in Firestore with the updated list.
- Handles errors by printing an error message if the update fails.


### GET SERVER VALUES

#### User Data Value - Handler 
```swift
getUserData(parameterName:completion:)
```

**Description:** 

Fetches a specific piece of data for the current user from the `users` collection in Firebase Firestore. The data is identified by the parameter name provided. 

**Parameters:**

- `parameterName`: The name of the parameter to retrieve (e.g., "level", "totalExp").
- `completion`: A closure that is called with the retrieved data.

**Usage:** 
This function retrieves data asynchronously from the Firestore database and passes it to the completion handler.

**Note:**
Becarefull when use this method if parameter is not match app will crash. Check the [paramters](../../databases/models/userinfomodel.md#userinfomodel-structure)

#### User Data Value - Async 
```swift 
getUserDatas(parameterName:)
```

**Description:** 

Asynchronously retrieves a specific piece of data for the current user from the `users` collection in Firebase Firestore, using async/await syntax.

**Parameters:**

- `parameterName`: The name of the parameter to retrieve.

**Returns:**

- `Any`: The retrieved data or an error if the user is unauthorized.

**Note:**
Becarefull when use this method if parameter is not match app will crash. Check the [paramters](../../databases/models/userinfomodel.md#userinfomodel-structure)

**Usage:** 
Use this method to asynchronously fetch user data. It returns the value directly or throws an error if fetching fails.

#### Level Parameters
```swift
getLevelData(level:parameterName:completion:)
```

**Description:** 

Fetches a specific piece of data related to a particular level from the `levels` collection in Firebase Firestore.

**Parameters:**

- `level`: The level identifier (e.g., "1", "2").
- `parameterName`: The name of the parameter to retrieve (e.g., "logo", "cap").
- `completion`: A closure that is called with the retrieved data.

**Usage:** 
This function is used to fetch data about game levels and pass the result to a completion handler.

#### Current Level 
```swift 
getCurrentLevelData()
```

**Description:** 

Retrieves the current user's level information, including the level logo, level cap, total experience points, and consecutive login value.

**Usage:** 
Calls `getUserData` and `getLevelData` to gather and update all relevant level and user experience information.

#### Daily Infromation
```swift 
getDailyInformation()
```

**Description:** 

Retrieves and updates the status of daily rewards and mission rewards for the current user.

**Usage:** 

Fetches daily and mission rewards data from Firebase and updates local properties accordingly.

#### Exp Booster Remaning Time
```swift
getRemainingTime(completion:)
```

**Description:** 

Calculates the remaining time for an active booster and returns it in seconds. The booster end date is fetched and compared to the current date.

**Parameters:**

- `completion`: A closure that is called with the remaining time in seconds.

**Usage:** 

Fetches the expiration date of a booster, calculates the remaining time, and returns it via the completion handler.

#### Compare Last Login Date 
```swift
isLoggedInSameDay() -> Bool
```

**Description:** 

Determines if the last login day is the same as the current day.

**Returns:**

- `Bool`: `true` if the user logged in today, `false` otherwise.

**Usage:** 

Used to check if the user has logged in on the same day for reward or login tracking purposes.

#### Query - Blocked List
```swift 
isInBlockedList(uuid:) -> Bool
```

**Description:** 

Checks if a specific user ID is present in the current user's blocked list.

**Parameters:**

- `uuid`: The user ID to check.

**Returns:**

- `Bool`: `true` if the user ID is in the blocked list, `false` otherwise.

**Usage:** 
Asynchronously checks if a user ID is blocked by querying the Firestore document.

#### Query - Hidden Message List
```swift
isInHiddenMessagesList(uuid:) -> Bool
```

**Description:** 

Checks if a specific user ID is present in the current user's hidden messages list.

**Parameters:**

- `uuid`: The user ID to check.

**Returns:**

- `Bool`: `true` if the user ID is in the hidden messages list, `false` otherwise.

**Usage:** 
Asynchronously checks if a user ID is hidden from the message list.

#### Sender Level
```swift
senderLevelLogo(uuid:) -> String
```

**Description:** 

Fetches the level logo for a given sender's user ID.

**Parameters:**

- `uuid`: The user ID of the message sender.

**Returns:**

- `String`: The level logo of the sender.

**Usage:** 

Asynchronously retrieves the level logo for a specific user by first fetching their level and then fetching the corresponding logo from the `levels` collection.

#### Query - Owned Item
```swift
isUserOwnedItem(item_name:) -> Bool
```

**Description:** 

Checks if the current user owns a specific item.

**Parameters:**

- `item_name`: The name of the item to check.

**Returns:**

- `Bool`: `true` if the item is owned, `false` otherwise.

**Usage:** 

Asynchronously checks if a specific item is present in the user's list of owned items. If an error occurs or the item is not found, it returns `false`.


<!-- ### Overview

This script provides various utility functions for managing user data and rewards in a Swift application. It includes functionalities for converting time values, resetting login streaks, deleting messages, reporting users, retrieving mission rewards, and managing rewards based on user levels. It interacts with Firebase for data storage and retrieval. -->

### OTHER 

#### Time Converter
```swift
timeString(time: Int) -> String
```

**Description:** Converts an integer value representing seconds into a formatted time string (HH : mm : ss).

**Parameters:**

- `time`: An `Int` representing the number of seconds to be converted.

**Returns:** A `String` in the format "HH : mm : ss".

#### Reset the Consecutive Login
```swift
resetConsecutiveLogin()
```

**Description:** Resets the consecutive login count to zero if it exceeds a threshold. Updates the Firestore document for the current user.

**Parameters:** None.

**Usage:** This function is used to reset the consecutive login count when it exceeds 6 days.


#### Remove Message
```swift
deleteMsg(uuid: String) async
```

**Description:** Deletes a message document from Firestore based on its UUID.

**Parameters:**

- `uuid`: A `String` representing the UUID of the message to be deleted.

**Usage:** Use this function to remove a specific message from the Firestore database.

#### Report the User
```swift
userReport(reason: String, report_uid: String, date: Date, msg_id: String)
```

**Description:** Reports a user to Firestore with the provided details.

**Parameters:**

- `reason`: A `String` explaining the reason for the report.
- `report_uid`: The user ID of the reported user.
- `date`: The date of the report.
- `msg_id`: The ID of the message associated with the report.

**Usage:** Use this function to report users for inappropriate behavior or other reasons.

#### Mission Reward Status
```swift
getMissionRewardsValue(index: Int) async -> Bool
```

**Description:** Retrieves the mission rewards value at a specified index from user data.

**Parameters:**

- `index`: An `Int` representing the index of the mission rewards array.

**Returns:** A `Bool` indicating the reward status at the specified index.


#### Download Url List
```swift
getListDownloadLinks(path: String) async -> [String]
```

**Description:** Retrieves a list of download links for items stored in Firebase Storage at a specified path. Mainly create get emoji and animated emoji download url list.

**Parameters:**

- `path`: A `String` representing the path in Firebase Storage.

**Returns:** An array of `String` representing the download URLs for the items.


#### Get Level Reward 
```swift
getLevelReward(level: Int)
```

**Description:** Grants a reward based on the user's level. Different rewards are given for different levels.

**Parameters:**

- `level`: An `Int` representing the user's current level.

**Usage:** Call this function when the user reaches a new level to grant appropriate rewards.

#### Reward Functions

##### Level 2
```swift
levelLabelReward()
```
**Description:** Activates a level label for level 2 reward.
  
##### Level 5
```swift
randomItemReward()
```

**Description:** Grants a random background color at level 5.

##### Level 10
```swift
doubleEXPReward()
```

**Description:** Grants a 3-day experience multiplier at level 10.

##### Level 15
```swift
uiSkinRewards()
```

**Description:** Grants a random UI skin at level 15.


##### Level 20
```swift
fontStyleReward()
```

**Description:** Grants a random font style at level 20.


##### Level 25
```swift
emojiReward()
```
**Description:** Grants a random emoji at level 25.


##### Level 30
```swift
animatedEmojiReward()
```

**Description:** Grants a random animated emoji at level 30.



### Dependencies

- **FirebaseManager**: Handles interactions with Firebase Authentication, Firestore, and Storage.
- **UserInfoConstants**: Contains constants related to user information keys.
- **FirebaseCollectionConstants**: Contains constants for Firestore collection names.
- **ReasonsConstant**: Contains keys related to user report reasons.
- **SettingBindingValues**: Manages user settings and values for rewards.
- **FirebaseUserInfoViewModel**: Updates user information and owned items list.
- **AccountServiceViewModel**: Manages in-app purchases and boosters.
- **Url_Lists**: Contains lists of URL constants for emojis and other resources.

