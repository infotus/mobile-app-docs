---
title: Response
weight: 2
---

## API Response

This documentation covers the data structures and error handling used for interacting with the Cheer Supports API.

### Error Handling

#### AuthenticationError

- **invalidCredentials**: Indicates that the provided credentials are invalid.
- **custom(errorMessage: String)**: Custom error with a specific error message.

#### PathError

- **invalidUrl**: The URL used in the request is invalid.
- **noData**: No data was received in the response.
- **nullAvatar**: The avatar data is null or not available.
- **decodingError**: Error occurred while decoding the response data.
- **custom(errorMessage: String)**: Custom error with a specific error message.

#### PurchaseError

- **invalidUrl**: The URL used for the purchase request is invalid.
- **invalidKey**: The provided key is invalid.
- **unauthorized**: Unauthorized access error.
- **post_request_error**: Error occurred during the POST request.
- **decoding_error**: Error occurred while decoding the response data.
- **custom(errorMessage: String)**: Custom error with a specific error message.

#### Deletion

- **invalidCredentials**: Invalid credentials provided for account deletion.
- **unauthorized**: Unauthorized access error for account deletion.
- **custom(errorMessage: String)**: Custom error with a specific error message.

### API Request Body Structures

#### LoginRequestBody

```swift
struct LoginRequestBody: Codable {
    let email: String
    let password: String
}
```

- **email**: The user's email address.
- **password**: The user's password.

#### Route602RequestBody

```swift
struct Route602RequestBody: Codable {
    let user_id: String
    let quantity: Int
    let price: Int
    let platform: String
    let item_id: String
}
```

- **user_id**: The ID of the user.
- **quantity**: The quantity of the item.
- **price**: The price of the item.
- **platform**: The platform on which the transaction is made.
- **item_id**: The ID of the item.

#### Route132DeletionRequestBody

```swift
struct Route132DeletionRequestBody: Codable {
    let user_id: String
    let category: Int
    let content: String
    let language: String
}
```

- **user_id**: The ID of the user requesting deletion.
- **category**: The category of the deletion request.
- **content**: The content of the deletion request.
- **language**: The language of the request.

### API Response Data Structures

#### Route100Response

```swift
struct Route100Response: Codable {
    let token: String?
    let user_id: Int?
    let handle_name: String?
    let nick_name: String?
    let callback_url: String?
    let offer_is_enabled: Bool?
    let message: String?
    let success: Bool?
}
```

- **token**: Authentication token for the user.
- **user_id**: The ID of the user.
- **handle_name**: The handle name of the user.
- **nick_name**: The nickname of the user.
- **callback_url**: URL to redirect after login.
- **offer_is_enabled**: Indicates if offers are enabled for the user.
- **message**: Response message.
- **success**: Indicates if the login was successful.

#### UserCoins

```swift
struct UserCoins: Codable {
    let amount: String?
}
```

- **amount**: The amount of cheer coins the user has.

#### Route129Response

```swift
struct Route129Response: Codable {
    let id, userID: Int
    let sessionID: String
    let categoryID: Int
    let offerID, giftCategoryID: Int?
    let liveStartAt: String?
    let liveEndAt: String?
    let status, publishType: String
    let banFlag: Int
    let hash: String
    let scheduledDatetime: String?
    let scheduledComment: String?
    let subscriberCount: Int
    let createdAt, updatedAt: String?
    let deletedAt: String?
    
    enum CodingKeys: String, CodingKey {
        case id
        case userID = "user_id"
        case sessionID = "session_id"
        case categoryID = "category_id"
        case offerID = "offer_id"
        case giftCategoryID = "gift_category_id"
        case liveStartAt = "live_start_at"
        case liveEndAt = "live_end_at"
        case status = "status"
        case publishType = "publish_type"
        case banFlag = "ban_flag"
        case hash = "hash"
        case scheduledDatetime = "scheduled_datetime"
        case scheduledComment = "scheduled_comment"
        case subscriberCount = "subscriber_count"
        case createdAt = "created_at"
        case updatedAt = "updated_at"
        case deletedAt = "deleted_at"
    }
}
```

- **id**: The ID of the response.
- **userID**: The ID of the user.
- **sessionID**: The session ID of the stream.
- **categoryID**: The category ID of the stream.
- **offerID**: The offer ID associated with the stream.
- **giftCategoryID**: The gift category ID.
- **liveStartAt**: The start time of the live stream.
- **liveEndAt**: The end time of the live stream.
- **status**: The status of the stream.
- **publishType**: The type of publication.
- **banFlag**: Flag indicating if the user is banned.
- **hash**: Hash value associated with the stream.
- **scheduledDatetime**: The scheduled datetime of the stream.
- **scheduledComment**: The comment scheduled for the stream.
- **subscriberCount**: The number of subscribers.
- **createdAt**: The creation time of the stream.
- **updatedAt**: The last update time of the stream.
- **deletedAt**: The deletion time of the stream.

#### Route143Response

```swift
struct Route143Response: Codable {
    let id: Int
    let userID: Int
    let type: String
    let fileName: String
    let filePath: String
    let originalName: String
    
    enum CodingKeys: String, CodingKey {
        case id
        case userID = "user_id"
        case type
        case fileName = "file_name"
        case filePath = "file_path"
        case originalName = "original_name"
    }
}
```

- **id**: The ID of the file.
- **userID**: The ID of the user.
- **type**: The type of the file.
- **fileName**: The name of the file.
- **filePath**: The path of the file.
- **originalName**: The original name of the file.

#### Route195Response

```swift
struct Route195Response: Codable {
    let liverData: Liver?
    let userData: User?
    let channelData: Channel?
    let followID: Int?
    let liverCheck: [Int]?
    let id: Int
    
    enum CodingKeys: String, CodingKey {
        case liverData = "liver_data"
        case userData = "user_data"
        case channelData = "channel_data"
        case followID = "follow_id"
        case liverCheck = "liver_check"
        case id
    }
}
```

- **liverData**: Data related to the liver.
- **userData**: Data related to the user.
- **channelData**: Data related to the channel.
- **followID**: The ID of the follow relationship.
- **liverCheck**: Array of liver check IDs.
- **id**: The ID of the response.

##### Liver

```swift
struct Liver: Codable {
    let id, userID: Int
    let categoryID: Int?
    let profileIsVisible: Int?
    let userOption: Int?
    let profile: String?
    let liverGroupID: Int?
    let liverGroupDeletedAt: String?
    let backgroundPath: String?
    let iconPath: String?
    
    enum CodingKeys: String, CodingKey {
        case id
        case userID = "user_id"
        case categoryID = "category_id"
        case profileIsVisible = "profile_is_visible"
        case userOption = "user_option"
        case profile
        case liverGroupID = "liver_group_id"
        case liverGroupDeletedAt = "liver_group_deleted_at"
        case backgroundPath = "background_path"
        case iconPath = "icon_path"
    }
}
```

- **id**: The ID of the liver.
- **userID**: The ID of the user associated with the liver.
- **categoryID**: The category ID of the liver.
- **profileIsVisible**: Indicates if the profile is visible.
- **userOption**: User options related to the liver.
- **profile**: The profile of the liver.
- **liverGroupID**: The liver group ID.
- **liverGroupDeletedAt**: Timestamp when the liver group was deleted.
- **backgroundPath**: The path to the background image.
- **iconPath**: The path to the icon image.

##### User

```swift
struct User: Codable {
    let id: Int
    let nickName: String?
    let currentPiyo, user

Option: Int?
    let totalRanking: Int?
    let cheerTotal, cheerSendTotal, piyoCount, likeCount: Int?
    let followCount, followerCount: Int?
    
    enum CodingKeys: String, CodingKey {
        case id
        case nickName = "nick_name"
        case currentPiyo = "current_piyo"
        case userOption = "user_option"
        case totalRanking = "total_ranking"
        case cheerTotal = "cheer_total"
        case cheerSendTotal = "cheer_send_total"
        case piyoCount = "piyo_count"
        case likeCount = "like_count"
        case followCount = "follow_count"
        case followerCount = "follower_count"
    }
}
```

- **id**: The ID of the user.
- **nickName**: The nickname of the user.
- **currentPiyo**: The current piyo count.
- **userOption**: User options.
- **totalRanking**: The total ranking of the user.
- **cheerTotal**: The total number of cheers.
- **cheerSendTotal**: The total number of cheers sent.
- **piyoCount**: The piyo count.
- **likeCount**: The like count.
- **followCount**: The follow count.
- **followerCount**: The follower count.

##### Channel

```swift
struct Channel: Codable {
    let id: Int
    let status: String?
    let scheduledDatetime: String?
    let scheduledComment: String?
    let sessionID: String?
    let giftCategoryID: Int?
    let channelDeliveryID: Int?
    
    enum CodingKeys: String, CodingKey {
        case id
        case status
        case scheduledDatetime = "scheduled_datetime"
        case scheduledComment = "scheduled_comment"
        case sessionID = "session_id"
        case giftCategoryID = "gift_category_id"
        case channelDeliveryID = "channel_delivery_id"
    }
}
```

- **id**: The ID of the channel.
- **status**: The status of the channel.
- **scheduledDatetime**: The scheduled datetime for the channel.
- **scheduledComment**: The scheduled comment for the channel.
- **sessionID**: The session ID associated with the channel.
- **giftCategoryID**: The ID of the gift category.
- **channelDeliveryID**: The ID of the channel delivery.

#### Route196Response

```swift
struct Route196Response: Codable {
    let totalCount: Int?
    let livers: [Liver_196]
    
    enum CodingKeys: String, CodingKey {
        case totalCount = "total_count"
        case livers
    }
}

struct Liver_196: Codable {
    let liverID, userOption, userID, channelID: Int?
    let categoryID: Int?
    let nickName: String?
    let profile: String?
    let status: String?
    let scheduledDatetime, scheduledComment, subscriberCount: String?
    let cheerTotal, followerCount, followCount, followID: Int?
    let isFollowed: Bool?
    let headerPath, iconPath: String?
    
    enum CodingKeys: String, CodingKey {
        case liverID = "liver_id"
        case userOption = "user_option"
        case userID = "user_id"
        case channelID = "channel_id"
        case categoryID = "category_id"
        case nickName = "nick_name"
        case profile
        case status
        case scheduledDatetime = "scheduled_datetime"
        case scheduledComment = "scheduled_comment"
        case subscriberCount = "subscriber_count"
        case cheerTotal = "cheer_total"
        case followerCount = "follower_count"
        case followCount = "follow_count"
        case followID = "follow_id"
        case isFollowed = "is_followed"
        case headerPath = "header_path"
        case iconPath = "icon_path"
    }
}
```

- **totalCount**: The total count of livers.
- **livers**: Array of liver data.

##### Liver_196

- **liverID**: The ID of the liver.
- **userOption**: User options.
- **userID**: The ID of the user.
- **channelID**: The ID of the channel.
- **categoryID**: The category ID.
- **nickName**: The nickname of the liver.
- **profile**: The profile of the liver.
- **status**: The status of the liver.
- **scheduledDatetime**: The scheduled datetime.
- **scheduledComment**: The scheduled comment.
- **subscriberCount**: The number of subscribers.
- **cheerTotal**: The total number of cheers.
- **followerCount**: The number of followers.
- **followCount**: The number of follows.
- **followID**: The ID of the follow relationship.
- **isFollowed**: Indicates if the liver is followed.
- **headerPath**: The path to the header image.
- **iconPath**: The path to the icon image.

#### Route602Response

```swift
struct Route602Response: Codable {
    let current_point: Int?
    let user_id: Int?
}
```

- **current_point**: The current points of the user.
- **user_id**: The ID of the user.

#### Route603Response

```swift
struct Route603Response: Codable {
    let liveStart: String
    let liveEnd: String
    
    enum CodingKeys: String, CodingKey {
        case liveStart = "live_start_at"
        case liveEnd = "live_end_at"
    }
}
```

- **liveStart**: The start time of the live stream.
- **liveEnd**: The end time of the live stream.

#### Route604Response

```swift
struct Route604Response: Codable {
    let subscribe_start: String
    let subscribe_end: String
    
    enum CodingKeys: String, CodingKey {
        case subscribe_start = "subscribe_start_at"
        case subscribe_end = "subscribe_end_at"
    }
}
```

- **subscribe_start**: The start time of the subscription.
- **subscribe_end**: The end time of the subscription.

#### Route605Response

```swift
struct Route605Response: Codable {
    let gift_id: Int
    let receiver_id: Int
    let created: String
    
    enum CodingKeys: String, CodingKey {
        case gift_id
        case receiver_id = "userId_recieved_gift"
        case created = "created_at"
    }
}
```

- **gift_id**: The ID of the gift.
- **receiver_id**: The ID of the user who received the gift.
- **created**: The timestamp when the gift was created.

