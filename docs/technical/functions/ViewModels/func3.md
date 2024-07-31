---
title: "Message"
weight: 2
---

# Technical Documentation for `MsgMenuModel`

## Overview

`MsgMenuModel` is an `ObservableObject` class used for managing and interacting with chat messages in a SwiftUI application. It handles message retrieval, uploading images, and updating the UI in response to changes in Firestore. It also provides methods to manipulate message visibility and manage user avatars.

## Properties

- `@Published var txt: String` : The text of the current message being composed.
  
- `@Published var userAvatar: String` : URL path for the user's avatar image.
  
- `@Published var imageUrlPath: String` : URL path for the image associated with the current message.
  
- `@Published var msgs: [MsgModel]` : Array of `MsgModel` objects representing the messages in the chat.
  
- `@Published var image_is_ready: Bool` : Indicates whether the image associated with a message is ready.
  
- `@Published var msg_data: MsgModel` : The message data for the current message being processed.
  
- `@Published var msg_Index: Int` : Index of the message in the `msgs` array.
  
- `@Published var showLevel: Bool` : Indicates whether the level (likely a UI element) should be shown or hidden.

## Initializer

- **`init()`** : Initializes the `MsgMenuModel` object and triggers the reading of all messages from Firestore.

## Methods

### Show Alert
```swift
alertView(title: String, message: String) -> UIAlertController
```

**Description:** Creates and returns a `UIAlertController` with the given title and message.

**Parameters:**

- `title`: The title of the alert.
- `message`: The message body of the alert.

**Returns:** A configured `UIAlertController` instance.

### Read All Message
```swift
readAllMsgs()
```

**Description:** Listens to changes in the "Msgs" collection in Firestore and updates the `msgs` array based on added, modified, or removed documents.

**Usage:** Automatically called on initialization to start listening for message updates.

### Send Message
```swift
writeMsg(path: String, text: String, user: String, name: String, iconPath: String, uuid: String)
```

**Description:** Writes a new message to the Firestore database.

**Parameters:**

- `path`: Path to the image associated with the message.
- `text`: The text content of the message.
- `user`: The user ID of the message sender.
- `name`: The name of the message sender.
- `iconPath`: URL path to the user's avatar icon.
- `uuid`: Unique identifier for the message.

### Upload Image to Firebase Storage
```swift
uploadImageToStorage(image: UIImage, completion: @escaping(String) -> Void) async throws
```

**Description:** Uploads an image to Firebase Storage and returns the download URL via a completion handler.

**Parameters:**

- `image`: The `UIImage` to be uploaded.
- `completion`: Closure to be called with the URL string upon successful upload.

**Throws:** Errors related to image resizing or upload failures.

### Decrease Size of the Image
```swift
resizeImage(image: UIImage, targetSize: CGSize) -> UIImage?
```

**Description:** Resizes the provided image to the specified target size.

**Parameters:**

- `image`: The `UIImage` to be resized.
- `targetSize`: The desired size for the resized image.

**Returns:** A resized `UIImage` or `nil` if resizing fails.

### Fetch Avatar
```swift
fetchAvatar()
```

**Description:** Fetches the user avatar from Firestore and updates the `userAvatar` property.

**Usage:** Typically used to retrieve and display the user's avatar after login.

### Hide Blocked Messages 
```swift
hideBlockedUserMessages(uuid: String) async
```

**Description:** Filters out messages from a blocked user based on their UUID.

**Parameters:**

- `uuid`: The UUID of the blocked user.

**Usage:** Used to remove messages from users who have been blocked.


### Remove Message
```swift
hideFromTheList(index: Int) async
```

**Description:** Removes a message from the list at the specified index.

**Parameters:**

- `index`: The index of the message to be removed.

### Unhide the Message
```swift
showInTheList(data: MsgModel, index: Int) async
```

**Description:** Inserts a message into the list at the specified index.

**Parameters:**

- `data`: The `MsgModel` to be inserted.
- `index`: The index at which the message should be inserted.

## Usage

The `MsgMenuModel` class is designed to manage chat messages within a SwiftUI application. It provides functionalities for fetching and displaying messages, uploading images, and handling user avatars. The class leverages Firebase Firestore for real-time message updates and Firebase Storage for image handling. SwiftUI views can bind to `MsgMenuModel`'s `@Published` properties to automatically update the UI in response to changes.
