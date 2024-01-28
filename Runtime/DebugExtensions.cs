using UnityEngine;

namespace Sanimal.Utility.Editor
{
    /// <summary>
    /// Debug类的附加方法
    /// </summary>
    public static class DebugExtensions
    {
        /// <summary>
        /// 绘制一个圆圈
        /// </summary>
        /// <param name="position">圆心位置</param>
        /// <param name="direction">圆圈朝向</param>
        /// <param name="radius">半径</param>
        /// <param name="color">颜色</param>
        /// <param name="step">每单位多少线段</param>
        public static void DrawCircle(Vector3 position, Vector3 direction, float radius, Color color, uint step = 10)
        {
            direction.Normalize();
            var secDir = Mathf.Abs(Vector3.Dot(direction, Vector3.up)) < 0.5f ? Vector3.up : Vector3.forward;
            var radiusDir = Vector3.Cross(direction, secDir).normalized * radius;
            var perimeter = 2 * Mathf.PI * radius;
            var stepCount = Mathf.Floor(perimeter * step);
            var roate = Quaternion.AngleAxis(360f / stepCount, direction);
            for (int i = 0; i < stepCount; i++)
            {
                var next = roate * radiusDir;
                Debug.DrawLine(position + radiusDir, position + next, color);
                radiusDir = next;
            }
        }
    }
}
