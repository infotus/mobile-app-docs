---
title: Reports Model
weight: 3
---

# Reports Model

This script defines a data model and related structures for managing reports in a Swift application using Firebase Firestore. It includes a model for report data, constants for Firestore field names, and a structure for report details.

**ReportsModel.swift**

### **Libraries**

- `Foundation`: Provides fundamental classes and services for Swift applications.
- `FirebaseFirestore`: Firebase SDK for integrating Firestore database services.

### **ReportsModel Structure**

```swift
struct ReportsModel: Codable, Identifiable, Hashable {
    @DocumentID var id: String?            // Unique Firestore document ID (optional)
    
    var userUID: String                    // ID of the user who made the report
    var date: Date                        // Date when the report was created
    var reason: String                    // Reason for the report
    var reportedUserUID: String           // ID of the user being reported
    var msg_id: String                    // ID of the message associated with the report
    
    enum CodingKeys: String, CodingKey {
        case id
        case userUID
        case date
        case reason
        case reportedUserUID
        case msg_id
    }
}
```

**Attributes:**
- `id`: The unique identifier for the Firestore document (optional and automatically assigned).
- `userUID`: A unique identifier for the user who submitted the report.
- `date`: The date when the report was created.
- `reason`: A description of why the report was made.
- `reportedUserUID`: The unique identifier of the user who is being reported.
- `msg_id`: The identifier of the message related to the report.

- **CodingKeys Enum**: Maps Swift property names to Firestore field names to facilitate encoding and decoding.

### **ReasonsConstant**

```swift
struct ReasonsConstant {
    static let user_uid = "UserUID"        // Field name for the user ID in Firestore
    static let reason = "Reason"           // Field name for the reason of the report
    static let reported_uid = "ReportedUID" // Field name for the reported user's ID
    static let msg_id = "MessageID"        // Field name for the message ID
    static let date = "Date"               // Field name for the report creation date
}
```

**Purpose**: Defines constants for Firestore field names to avoid hardcoding and to maintain consistency across the application.

### **ReasonDatas**

```swift
struct ReasonDatas {
    let user_uid: String                  // User ID of the reporter
    let reason: String                    // Reason for the report
    let reported_uid: String              // User ID of the reported user
    let msg_id: String                    // Message ID related to the report
    let date: Date                        // Date when the report was created
    
    init(user_uid: String, reason: String, reported_uid: String, msg_id: String, date: Date) {
        self.user_uid = user_uid
        self.reason = reason
        self.reported_uid = reported_uid
        self.msg_id = msg_id
        self.date = date
    }
}
```

**Purpose**: Represents the details of a report with an initializer for creating instances. This structure is used for managing report data in a type-safe manner.

### **Report Reasons**

The following are predefined reasons for reporting, which can be used to standardize the types of reports submitted:

- **Inappropriate Profile**: Report for profiles containing inappropriate content or behavior.
- **Sexual Message/Image**: Report for messages or images that contain sexual content.
- **Spam/Advertising**: Report for content that is classified as spam or unsolicited advertising.
- **Harassment**: Report for messages or behavior that constitutes harassment.
- **Fraud**: Report for actions or content involving fraudulent activity.

 
<!-- ## Summary

The script defines a structured way to handle report data in a Swift application integrated with Firebase Firestore. It provides a model for the reports, constants for Firestore field names, and a data structure for handling report details. This approach ensures consistency in accessing Firestore data and simplifies the management of report-related information. -->

---

