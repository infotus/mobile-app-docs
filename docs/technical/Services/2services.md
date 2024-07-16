# Intro

### Overview

In addition to the website services, three additional services have been integrated into the application to comply with specific App Store Review Guidelines. The Login Reward Service and Chat Service were implemented to meet the requirements of App Store Review Guideline [4.2](https://developer.apple.com/app-store/review/guidelines/#design), while the third service aligns with App Store Review Guideline [3.1.1](https://developer.apple.com/app-store/review/guidelines/#business).

User-related information is managed by Firebase, utilizing four main components: Authentication, Cloud Messaging, Storage, and Cloud Firestore.

Please note that the information provided here is for preview purposes only. Real credentials and details will be updated once the repository becomes private.


#### Credentials

- **Email:** [Admin Email]
- **Password:** [Admin Password]

#### Project Details

- **Project Name:** Cheer Supports Iphone only
- **Project ID:** cheer-supports-iphone
- **Project Number:** 12345676789 (fake)
- **Web API Key:** A2039475304ut9euwr40ruw9refu0e9urf (fake)
- **Public Facing Name:** Cheer Supports
- **Support Email:** test@test.com (fake)

#### Firebase SDK Setup and Configuration

- **App ID:** 1:299237459823454093868794586 (fake)
- **Encoded App ID:** app-1-299237459823454093868794586 (fake)
- **App Nickname:** Cheer Supports
- **Bundle ID:** com.cheer-supports (fake)
- **App Store ID:** 54908673459 (fake)
- **Team ID:** J8973U98w4u (fake)


#### Cloud Messaging

Firebase Cloud Messaging API V1 is utilized for notification services.

- **Sender ID:** 439280572 (fake)
- **Service Account:** JSON will be added later

##### APNs Setup

For proper notification functionality, ensure the following:

- APNs Auth Key and Production APNs Certificate files are shared separately. These files are crucial for notification services.

##### Legacy API Deprecation

Web Push Certificate is currently used for testing purposes only and was supported by Cloud Messaging API (Legacy) until July 22, 2024. Due to security concerns, Google has announced the shutdown of this API, which will be replaced with Firebase Cloud Messaging API V1. The new API utilizes OAuth 2.0 authentication. For more details, refer to [here](https://firebase.google.com/docs/cloud-messaging/migrate-v1).

##### Access and Configuration

Access to the cloud messaging service requires a Google API access token, obtainable through the service account. The management of this token and the notification service is handled by 'NotificationManager.swift'. For more information about the manager, please check [here]().



<!-- 
### Daily Login Tracking Service


### Chat Service


### In-App Purchase Service -->