---
title: Databases
weight: 3
---


# Databases

This application utilizes two hosting database platforms:

Certainly! Here's the updated AWS Database section with the additional information:

---

## AWS Database

The MySQL database is hosted on AWS and is primarily used for managing web content. The database includes the following tables:

- **in_app_purchases**: Stores information related to in-app purchases.
- **in_app_item_purchases**: Tracks individual item purchases within the application.

Only these two tables are created specifically for the application. Additionally, data from the following tables are utilized for various features:

- **Users**
- **Livers**
- **Channels**
- **follows**
- **user_own_item**

For further details, please refer to the web content documentation.

### Modules

![AWSModule](../img/modules/aws%20module.svg)

### Tables

#### users
- **id**: INTEGER (Primary Key)
- **nick_name**: VARCHAR(255)
- **current_point**: DECIMAL -> Description: Cheer Coins Value

Description: Stores user informations. The `users` table contains additional data values not directly related to the application. For more detailed information, please refer to the official website documentation.

#### livers
- **id**: INTEGER (Primary Key)
- **user_id**: INTEGER -> Foreign Key Reference: `users.id`

Description: Stores information about live streamers (livers) and their associated user IDs. The `livers` table contains additional data values not directly related to the application. For more detailed information, please refer to the official website documentation.

#### follows
- **id**: INTEGER (Primary Key)
- **user_id**: INTEGER -> Foreign Key Reference: `users.id`
- **liver_id**: INTEGER -> Foreign Key Reference: `livers.id`

Description: Tracks user follow relationships with livers. The `follows` table contains additional data values not directly related to the application. For more detailed information, please refer to the official website documentation.


#### user_own_item
- **id**: INTEGER (Primary Key)
- **user_id**: INTEGER -> Foreign Key Reference: `users.id`
- **type**: CHAR
- **file_name**: TEXT
- **file_path**: TEXT

Description: Manages items owned by users, including file details. The `user_own_item` table contains additional data values not directly related to the application. For more detailed information, please refer to the official website documentation.

#### channels
- **id**: INTEGER (Primary Key)
- **user_id**: INTEGER -> Foreign Key Reference: `users.id`
- **status**: CHAR
- **live_start_at**: TIMESTAMP
- **live_end_at**: TIMESTAMP

Description: The `channels` table contains additional data values not directly related to the application. For more detailed information, please refer to the official website documentation.

#### in_app_purchase
- **id**: INTEGER (Primary Key)
- **user_id**: INTEGER -> Foreign Key Reference: `users.id`
- **transaction_id**: VARCHAR(255)
- **transaction_type**: VARCHAR(255)
- **platform**: VARCHAR(255) -> Default: IOS
- **app_cheer**: INTEGER -> Description: Purchased Cheer Coin Value
- **used_flag**: INTEGER -> Description: Confirmation value for value is updated database
- **created_at**: TIMESTAMP
- **updated_at**: TIMESTAMP
- **deleted_at**: TIMESTAMP

Description: Records in-app purchases made by users, including transaction details and timestamps.
![CheerPurchase](../img/modules/cheer%20purchase.png)

#### in_app_item_purchase
- **id**: INTEGER (Primary Key)
- **user_id**: INTEGER -> Foreign Key Reference: `users.id`
- **price**: INTEGER
- **item_id**: VARCHAR(255)
- **platform**: VARCHAR(255)
- **quantity**: INTEGER
- **created_at**: TIMESTAMP
- **updated_at**: TIMESTAMP
- **deleted_at**: TIMESTAMP

Description: Logs purchases of in-app items, including price, item details, and timestamps.
![itempurchase](../img/modules/item%20purchase.png)

#### References:
- `users.id` referenced by:
    - `in_app_purchase.user_id`
    - `in_app_item_purchase.user_id`
    - `follows.user_id`
    - `livers.user_id`
    - `channels.user_id`
    - `user_own_item.user_id`

## Firebase Database

Firebase provides the second hosting service for this application, offering a NoSQL database. It comprises five collections:

- **Levels**: Stores data related to levels.
- **Msgs**: Stores messaging within the application.
- **Notification**: Stores notification data.
- **Reports**: Contains analytics and reporting data.
- **Users**: Stores user profiles and related information.

### Modules

![FirebaseModule](../img/modules/firebase%20db.svg)


### Tables (Collections)

#### Levels
- **id**: INTEGER (Primary Key)
- **cap**: INTEGER
- **logo**: VARCHAR

Description: Stores information about different levels, including their ID, cap value, and logo.

---

#### Msgs
- **id**: CHAR (Primary Key)
- **uuid**: CHAR
- **userID**: CHAR  -> Foreign Key Reference: `Users.userID`
- **msg**: VARCHAR
- **name**: CHAR
- **imagePath**: VARCHAR
- **urlPath**: VARCHAR
- **timeStamp**: TIMESTAMP

Description: Stores messages with associated user IDs, content, timestamp, and related details.

---

#### Notification
- **Access_Token**: CHAR (Primary Key)
- **updated_uuid**: CHAR
- **token**: VARCHAR
- **expired_time**: TIMESTAMP

Description: Manages notification tokens with associated access and expiration details.

---

#### Reports
- **id**: CHAR (Primary Key)
- **userUID**: CHAR -> Foreign Key Reference: `Users.id`
- **ReportedUID**: CHAR -> Foreign Key Reference: `Users.id`
- **MessageID**: CHAR -> Foreign Key Reference: `Msgs.id`
- **Reason**: CHAR
- **Date**: TIMESTAMP

Description: Stores reports on users, including reported user IDs, message IDs, reasons, and timestamps.

---

#### Users
- **id**: CHAR (Primary Key)
- **userID**: CHAR
- **TotalLogin**: INTEGER
- **TotalExp**: INTEGER
- **ShopPoints**: INTEGER
- **OwnedItems**: ARRAY
- **MissionRewards**: ARRAY
- **Level**: INTEGER -> Foreign Key Reference: `Levels.id`
- **LastLogin**: TIMESTAMP
- **HiddenMessages**: ARRAY
- **FCMToken**: VARCHAR
- **ExpBoosterEndDay**: TIMESTAMP
- **DailyReward**: BOOLEAN
- **ConsecutiveLogin**: INTEGER

Description: Stores user profiles, including login statistics, points, owned items, mission rewards, current level, login timestamps, notification tokens, and other related attributes.

---

#### References:
- `Users.id` referenced by:
    - `Msgs.uuid`
    - `Reports.userUID`
    - `Reports.ReportedUID`
    - `Notification.updated_uuid`
- `Users.userID` referenced by:
    - `Msgs.userID`
- `Levels.id` referenced by:
    - `Users.Level`
- `Msgs.id` referenced by:
    - `Reports.MessageID`


##  Models 

### MsgModel

#### Imports
```swift
import SwiftUI
import Firebase
import FirebaseFirestoreSwift
```

- **SwiftUI**: Framework for building user interfaces.
- **Firebase**: Backend-as-a-Service platform used for real-time databases, authentication, and more.
- **FirebaseFirestoreSwift**: Firebase library that provides Swift-specific extensions for Firestore, including Codable support.

```swift
struct MsgModel: Codable, Identifiable, Hashable {
    
    @DocumentID var id: String?
    
    var userID: String? = nil
    var msg: String? = nil
    var name: String? = nil // nickname
    var timeStamp: Date
    var urlPath: String? = nil // avatar link
    var imagePath: String? = nil
    var uuid: String?
    
    enum Codingkeys: String, CodingKey {
        case id
        case userID
        case msg
        case name
        case timeStamp
        case urlPath
        case imagePath
        case uuid
    }
}
```

- **Description**: Represents a message model conforming to Codable, Identifiable, and Hashable protocols for use with Firebase Firestore.
  
- **Properties**:
  - `id`: Optional String (`@DocumentID` property wrapper) - Unique identifier for the message document in Firestore.
  - `userID`: Optional String - User ID associated with the message.
  - `msg`: Optional String - Message content.
  - `name`: Optional String - Nickname associated with the user.
  - `timeStamp`: Date - Timestamp indicating when the message was created.
  - `urlPath`: Optional String - URL link to the user's avatar.
  - `imagePath`: Optional String - Path to an image associated with the message.
  - `uuid`: Optional String - Universally unique identifier for the message.

- **CodingKeys Enum**: Specifies the mapping between the Swift property names and the corresponding Firestore document field names.

#### Notes:
- **Firestore Integration**: This model is designed to integrate with Firestore, allowing seamless conversion between Firestore documents and Swift objects using Codable protocols.
- **Firebase FirestoreSwift**: Utilizes the `@DocumentID` property wrapper from `FirebaseFirestoreSwift` to manage document IDs directly within the Swift struct.
- **SwiftUI Compatibility**: The script imports SwiftUI, indicating potential integration with SwiftUI views or components, though not directly evident from the provided script.

This documentation provides a clear overview of the `MsgModel` struct, its properties, and its intended use with Firebase Firestore for managing message data within the application.