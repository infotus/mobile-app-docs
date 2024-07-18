# Firestore

## 1. Introduction

This document serves as a technical guide for developers involved in the iOS app development project utilizing Firebase Cloud Firestore.

## 2. Firebase Cloud Firestore Overview

### Features
- Real-time database synchronization
- Scalable NoSQL database
- Automatic and efficient data syncing

### Benefits
- Seamless integration with Firebase ecosystem
- Robust querying capabilities
- Reliable offline support

### Integration with iOS
- Firebase SDK integration
- Authentication and security features
- Cloud Functions for backend logic

## 3. Collections and Document Structure

The app utilizes five main collections within Firebase Cloud Firestore:

- **Levels**
- **Msgs**
- **Notification**
- **Users**
- **Report**

Each collection has a specific purpose and is structured to efficiently store and retrieve data relevant to the application's functionality.

## 4. Levels Collection

The Levels collection stores data related to the level and its capacity. This system distinguishes between active and inactive users. Active users are eligible to receive free items.

## 5. Msgs Collection

The **Msgs** collection stores messages or chat data exchanged within the app.


The **Msgs** collection in Firebase Firestore manages data related to messages sent within the application. This collection is crucial for storing and retrieving communication content between users, facilitating seamless interaction and communication features.


The **Msgs** collection serves several key purposes:

- **Communication**: Stores textual content and multimedia attachments exchanged between users, facilitating seamless communication and interaction within the application.
  
- **Content Management**: Manages URLs to external resources or attachments associated with messages, enriching message content and enhancing user experience.
  
- **Timestamp Tracking**: Records the precise time and date of message interactions, enabling chronological organization and historical reference within message threads.
  
- **User Identification**: Associates messages with specific users (identified by `userID`), ensuring message attribution and facilitating targeted communication features.

## 6. Notification Collection

The Notification collection manages access tokens and service account information necessary for authentication and secure communication with external services.

## 7. Users Collection

The **User** collection in Firebase Firestore stores essential data related to user activities and preferences within the application. This collection is pivotal for maintaining user-specific information and enhancing personalized user experiences.

The **User** collection serves several key purposes:

- **Personalization**: Stores user-specific settings, preferences, and progress data to tailor the application experience.
- **Engagement**: Tracks user activity metrics such as login streaks, rewards claimed, and mission progress to enhance user engagement and retention.
- **Data Management**: Facilitates efficient management of user-related data, ensuring seamless operation and scalability of the application.
- **Analytics**: Provides valuable insights into user behavior and interaction patterns, informing strategic decisions and feature enhancements.

## 8. Report Collection

The Report collection stores user-generated reports or feedback submitted within the app.

## 9. Security Rules

Firebase Cloud Firestore security rules are implemented to restrict access and ensure data privacy and integrity.

## 10. Maintenance and Updates

Guidelines for maintaining and updating Firestore collections and app integration over time.

This technical documentation provides comprehensive guidance on utilizing Firebase Cloud Firestore for an iOS app, specifically focusing on the five collections: Levels, Msgs, Notification, Users, and Report. It serves as a valuable resource for developers involved in the project's lifecycle.

