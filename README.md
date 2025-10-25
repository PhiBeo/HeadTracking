# 🧠 Unity Face Tracking (MediaPipe Integration)

Real-time face landmark detection and head-tracking demo using **[homuler’s MediaPipe Unity Plugin](https://github.com/homuler/MediaPipeUnityPlugin)**.  
The project maps detected facial movements to the Unity camera to simulate VR-like head motion.

---

## 🚀 Features

- 🎯 **Real-time Face Landmark Tracking** via webcam  
- 🧭 **Head Rotation Simulation** using landmark orientation  
- 🧩 **Smooth Camera Motion** with quaternion interpolation  

---

## 🧰 Tools & Libraries

| Tool / Library | Purpose | Version |
|----------------|----------|----------|
| **Unity** | Game Engine | 6000.0.59f2 |
| **MediaPipe Unity Plugin (homuler)** | Face landmark detection | v0.16.2 |
| **MediaPipe Tasks API** | Core Vision Task system | - |

---

## 🧩 Development Approach

1. **MediaPipe Integration**
   - Installed `MediaPipeUnityPlugin` (v0.16.2) and configured **Face Landmarker**.
   - Real-time video frames are streamed to `FaceLandmarkerResult`.

2. **Head Tracking**
   - Created a `HeadTracking` script to read key landmark points.
   - Calculated approximate **yaw**, **pitch**, and **roll** from facial geometry.
   - Applied smoothed rotation to the main camera using:
     ```csharp
     transform.localRotation = Quaternion.Slerp(
         transform.localRotation,
         targetRotation,
         Time.deltaTime * smoothSpeed
     );
     ```

3. **Scene Setup**
   - Built a **5m x 5m** environment (`Plane` scaled to 5x5 meters).
   - Left the **center 1m x 1m** area empty.
   - Placed props or background visuals around the border region.

---

## 🧪 Testing Environment

| Component | Details |
|------------|----------|
| **OS** | Windows 10 / 11 |
| **Unity Version** | 6000.0.59f2 |
| **MediaPipe Plugin** | v0.16.2 |
| **Hardware** | PC with webcam |
| **Input** | Live camera feed |
| **Output** | Camera rotation synced to user’s head motion |

---

## 📋 How to Run

1. Clone or download this project.  
2. Open in **Unity 6000.0.59f2**.  
3. Import **MediaPipeUnityPlugin v0.16.2** (The project should already included the package, but if not import **[homuler’s MediaPipe Unity Plugin](https://github.com/homuler/MediaPipeUnityPlugin)**).  
4. Open the main scene (e.g. `HeadTracking.unity`).  
5. Press **Play** — grant webcam access when prompted.
6. Give it a few second if run for the first time. 
7. Move your head and watch the in-game camera rotate accordingly.


---

## 🗺️ Demo Preview
![Face Tracking Demo](Demo/TrackingDemo.gif)
