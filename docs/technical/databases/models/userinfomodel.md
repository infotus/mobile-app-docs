---
title: User Info Model
weight: 2
---

# User Info Model

The script defines data models for managing user information in a Swift application, specifically one that integrates with Firebase for data storage and retrieval. It includes models for user information, constants for Firebase collections and parameters, and structures for user and level data.

**UserInfoModel.swift**

### **Libraries**

- `Foundation`: Provides fundamental classes and services for Swift applications.
- `SwiftUI`: Framework for building user interfaces.
- `Firebase`: Firebase SDK for integrating Firebase services.
- `FirebaseFirestoreSwift`: Firebase Firestore Swift extensions for easier handling of Firestore data.

### **UserInfoModel Structure**

```swift
struct UserInfoModel: Codable, Identifiable, Hashable {
    @DocumentID var id: String?             // Unique Firebase id
    var userID: String                     // User's ID in database
    var shopPoint: Int                     // User's earned Shop Points
    var totalExp: Int                      // User's earned total exp points
    var consecutiveLogin: Int             // Consecutive login value
    var totalLogin: Int                   // Total login days
    var ownedAllItems: [String]           // Owned name of the items list
    var lastLogin: Date                    // Last day login date
    var expBoosterEndDay: Date            // End date of the total booster
    var dailyReward: Bool                 // Daily rewards receive status
    var missionRewards: [Bool]            // Mission rewards receive status
    var blockedUsers: [String]            // List of blocked users UUID
    var hiddenMsgs: [String]              // List of hidden messages
    var fcmToken: String                  // Notification token

    enum CodingKeys: String, CodingKey {
        case id
        case userID
        case totalExp
        case consecutiveLogin
        case totalLogin
        case lastLogin
        case expBoosterEndDay
        case ownedAllItems
        case dailyReward
        case missionRewards
        case blockedUsers
        case hiddenMsgs
        case fcmToken
    }
}
```

**Attributes:**

- `id`: Firebase document ID (optional).
- `userID`: A unique identifier for the user within the database.
- `shopPoint`: The number of shop points the user has earned.
- `totalExp`: Total experience points earned by the user.
- `consecutiveLogin`: Number of consecutive login days.
- `totalLogin`: Total number of login days.
- `ownedAllItems`: List of item names owned by the user.
- `lastLogin`: The date of the last login.
- `expBoosterEndDay`: The date when the experience booster ends.
- `dailyReward`: Indicates whether the user has received daily rewards.
- `missionRewards`: Status of rewards received for missions.
- `blockedUsers`: List of UUIDs of users blocked by this user.
- `hiddenMsgs`: List of messages that are hidden.
- `fcmToken`: Firebase Cloud Messaging token for notifications.

### **FirebaseCollectionConstants**

```swift
struct FirebaseCollectionConstants {
    static let users = "Users"
    static let levels = "Levels"
    static let emojis = "Emojis"
    static let images = "Images"
    static let reports = "Reports"
    static let msgs = "Msgs"
    static let notification = "Notification"
}
```

**Purpose**: Holds constant values for Firebase collection names to avoid hardcoding strings throughout the codebase.

### **UserInfoConstants**

```swift
struct UserInfoConstants {
    static let userID = "UserID"                    // String
    static let shopPoint = "ShopPoints"             // Int
    static let totalExp = "TotalExp"                // Int
    static let consecutiveLogin = "ConsecutiveLogin" // Int
    static let totalLogin = "TotalLogin"            // Int
    static let level = "Level"                      // Int
    static let ownedItems = "OwnedItems"            // Array<String>
    static let lastLogin = "LastLogin"              // Date
    static let expBoosterEndDay = "ExpBoosterEndDay" // Date
    static let dailyReward = "DailyReward"          // Bool
    static let missionRewards = "MissionRewards"    // Array<Bool>
    static let blockedUsers = "BlockedUsers"        // Array<String>
    static let hiddenMsgs = "HiddenMessages"        // Array<String>
    static let fcmToken = "FCMToken"                // String
}
```

**Purpose**: Defines constants for database field names to maintain consistency and reduce errors.

### **UserDatas**

```swift
struct UserDatas: Codable {
    let userID: String
    let shopPoint: Int
    let totalExp: Int
    let consecutiveLogin: Int
    let totalLogin: Int
    let level: Int
    let ownedItems: [String]
    let lastLogin: Date
    let expBoosterEndDay: Date
    let dailyReward: Bool
    let missionRewards: [Bool]
    let blockedUsers: [String]
    let hiddenMsgs: [String]
    let fcmToken: String

    init(userID: String, shopPoint: Int, totalExp: Int, consecutiveLogin: Int, totalLogin: Int, level: Int, ownedItems: [String], lastLogin: Date, expBoosterEndDay: Date, dailyReward: Bool, missionRewards: [Bool], blockedUsers: [String], hiddenMsgs: [String], fcmToken: String) {
        self.userID = userID
        self.shopPoint = shopPoint
        self.totalExp = totalExp
        self.consecutiveLogin = consecutiveLogin
        self.totalLogin = totalLogin
        self.level = level
        self.ownedItems = ownedItems
        self.lastLogin = lastLogin
        self.expBoosterEndDay = expBoosterEndDay
        self.dailyReward = dailyReward
        self.missionRewards = missionRewards
        self.blockedUsers = blockedUsers
        self.hiddenMsgs = hiddenMsgs
        self.fcmToken = fcmToken
    }
}
```

**Purpose**: Represents user data with an initializer for creating instances.

### **LevelConstants**

```swift
struct LevelConstants {
    static let cap = "Cap"    // Int
    static let logo = "Logo"  // String
}
```

**Purpose**: Contains constant field names for level data in the database.

### **LevelDatas**

```swift
struct LevelDatas {
    let cap: Int
    let logo: String

    init(cap: Int, logo: String) {
        self.cap = cap
        self.logo = logo
    }
}
```

**Purpose**: Represents level data with an initializer for creating instances.

<!-- ## Summary

This script provides a structured way to handle user information and level data in a Swift application using Firebase. It defines models for user data, constants for Firebase collections and field names, and structures for user and level data. This approach ensures consistency, reduces errors, and simplifies the management of Firebase data. -->

---


