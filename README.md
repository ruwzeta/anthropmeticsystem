# Anthropometric System
Body measurement extraction using Open Pose

## WPF Application (WpfApp1)

The solution includes a WPF project named `WpfApp1`. Its specific purpose and interaction with the main `AnthropometricMeasure` web application are not clear from the existing codebase. It does not appear to be directly involved in the image processing or measurement calculation workflow.

**Recommendation:** Review the `WpfApp1` project. If it is no longer needed or is an unfinished component, consider removing it to simplify the solution. If it serves a purpose (e.g., as a utility, for testing, or a separate tool), its functionality and any relationship with the web application should be documented.

## Testing Recommendations

To improve the robustness and maintainability of this project, adding automated tests is highly recommended. Consider the following areas for unit and integration testing:

### Unit Tests

*   **`DistanceAlgo.cs`**:
    *   Test `distanceBetweenPoints()` with various inputs (zero distance, positive/negative coordinates, points on axes).
*   **`MatrixCal.cs`**:
    *   Thoroughly test all matrix operations: `MatrixCreate`, `MatrixProduct`, `MatrixInverse`, `MatrixIdentity`. Include tests for valid inputs, edge cases, and invalid inputs (e.g., incompatible dimensions, singular matrices for inversion).
*   **`JsonRead.cs` (`LoadJson` method)**:
    *   Test with valid sample JSON (confirming correct `MeasurementModel` population).
    *   Test with malformed/invalid JSON.
    *   Test with JSON files missing expected keypoints or data.
    *   Test with non-existent JSON file paths.
*   **`RatioAlgo.cs` (`matrixwcal` method)**:
    *   Verify that `matrixwcal()` produces the expected `matrixw` output given its hardcoded input matrices. This acts as a regression test for the calibration logic.

### Integration Tests

*   **`ImageUploadController.cs` (`PostFormData` method)**:
    *   Test successful image upload and (simulated) OpenPose processing, verifying the correct HTTP response and that the dummy JSON output is created as expected.
    *   Test with invalid file types (e.g., `.txt`, `.exe`).
    *   Test with files exceeding the defined size limits.
    *   Test behavior when no file is uploaded.
*   **`MeasurementController.cs` (`GetMeasurement` method)**:
    *   Test with a valid `jsonPath` query parameter, ensuring correct `MeasurementModel` retrieval.
    *   Test with a missing or empty `jsonPath`.
    *   Test with `jsonPath` values that are invalid (e.g., outside the allowed directory, non-existent file).

Consider using a testing framework like MSTest, NUnit, or xUnit for implementing these tests.
