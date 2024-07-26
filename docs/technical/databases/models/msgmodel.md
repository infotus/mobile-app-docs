---
title: MsgModel
weight: 1
---

# MsgModel

### Libraries
```swift
import SwiftUI
import Firebase
import FirebaseFirestoreSwift
```

- **SwiftUI**: Framework for building user interfaces.
- **Firebase**: Backend-as-a-Service platform used for real-time databases, authentication, and more.
- **FirebaseFirestoreSwift**: Firebase library that provides Swift-specific extensions for Firestore, including Codable support.


### Model
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

**Description**: Represents a message model conforming to Codable, Identifiable, and Hashable protocols for use with Firebase Firestore.
  
**Properties**:
- `id`: Optional String (`@DocumentID` property wrapper) - Unique identifier for the message document in Firestore.
- `userID`: Optional String - User ID associated with the message.
- `msg`: Optional String - Message content.
- `name`: Optional String - Nickname associated with the user.
- `timeStamp`: Date - Timestamp indicating when the message was created.
- `urlPath`: Optional String - URL link to the user's avatar.
- `imagePath`: Optional String - Path to an image associated with the message.
- `uuid`: Optional String - Universally unique identifier for the message.

- **CodingKeys Enum**: Specifies the mapping between the Swift property names and the corresponding Firestore document field names.

### Notes
- **Firestore Integration**: This model is designed to integrate with Firestore, allowing seamless conversion between Firestore documents and Swift objects using Codable protocols.
- **Firebase FirestoreSwift**: Utilizes the `@DocumentID` property wrapper from `FirebaseFirestoreSwift` to manage document IDs directly within the Swift struct.
- **SwiftUI Compatibility**: The script imports SwiftUI, indicating potential integration with SwiftUI views or components, though not directly evident from the provided script.

This documentation provides a clear overview of the `MsgModel` struct, its properties, and its intended use with Firebase Firestore for managing message data within the application.