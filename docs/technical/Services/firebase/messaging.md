---
title: Messaging
weight: 3
---

# Messaging

**Firebase Cloud Messaging Overview**

Firebase Messaging Service primarily functions as a notification service. It facilitates the delivery of notifications to users for various events such as new streams, incoming chat messages, updates on new versions, and other relevant notifications.

**Authentication**

Firebase Messaging Service employs OAuth 2.0 authentication, requiring an API access token for utilizing the Firebase Cloud Messaging service. The following source code outlines how to obtain the access token, includes logic for checking expiration times, and demonstrates sending messages to users.

**Using Firebase Cloud Messaging**

Firebase Cloud Messaging (FCM) enables developers to send notifications and messages to users. 

`NotificationManager.swift` automatically handles notifications between users. Notifications sent from administrators can be managed using the Firebase Messaging Console.

For detailed instructions and best practices on using Firebase Cloud Messaging effectively, refer to the Firebase documentation [here](https://firebase.google.com/docs/cloud-messaging/ios/client).



## Notfication Manager 

### Overview

`NotificationManager.swift` manages user notification permissions and Firebase Cloud Messaging (FCM) for the **Cheer Supports** iOS application. It handles notification permissions, sends notifications to users, and manages Firebase API access tokens.

### Class: NotificationManager

`NotificationManager` is an `ObservableObject` responsible for managing notifications and API access tokens.

#### Properties

- **hasPermission**: Indicates whether the app has notification permissions.
- **accessToken**: Stores the current Google API access token for Firebase messaging.
- **fcm_list**: An array storing FCM tokens of users currently using the app.

#### Initialization

The `NotificationManager` is initialized asynchronously to check and set notification permissions.

#### Methods

1. **request()**: Requests notification permissions from the user asynchronously using `UNUserNotificationCenter`.
   
2. **getAuthStatus()**: Checks the current notification authorization status asynchronously.

3. **sendMessageToDevice(msg: String, title: String)**: Sends a notification to all users using Firebase Cloud Messaging. It constructs a JSON payload and sends it via HTTP POST request.

4. **getAllFCMToken()**: Retrieves all FCM tokens from Firestore for users currently using the app.

5. **isAccessTokenExpired()**: Checks if the current Google API access token is expired asynchronously.

6. **updateAccessToken()**: Updates the Google API access token asynchronously using `ServiceAccountTokenProvider`.

7. **getAccessToken()**: Retrieves the current valid Google API access token asynchronously. It checks for expiration and updates if necessary.

8. **updateFirebaseNotificationValues()**: Updates Firebase Firestore with the current API access token and expiry time.

#### Error Handling

- Errors related to Firebase operations, network requests, and token management are logged but not explicitly handled within this class.

### Usage

To use `NotificationManager`, initialize an instance and call its methods asynchronously to manage notification permissions and send notifications.

### Example

```swift
// Example usage of NotificationManager

let notificationManager = NotificationManager()

// Request notification permissions
await notificationManager.request()

// Send a notification
do {
    await notificationManager.sendMessageToDevice(msg: "Hello from Cheer Supports!", title: "New Message")
} catch {
    print("Error sending notification: \(error.localizedDescription)")
}
```

### Dependencies

    - Firebase SDK (Firestore, Core, Authentication)
    - OAuth2 library for managing API access tokens


This documentation provides an overview of `NotificationManager.swift` functionality, its methods, properties, and usage examples within the **Cheer Supports** application context. Adjust details and add specific error handling or usage examples as needed for comprehensive documentation.
