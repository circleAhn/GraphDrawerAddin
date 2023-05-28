# GraphDrawerAddin (GrapX)

An `Microsoft PowerPoint Add-in` that draws a graph of a explicit / differentiate / integral function, tangent line, dot, etc.

The form of the design is similar to the image used in the Korean mathematics curriculum; such as svg format got from Geogebra.

<img src = "https://github.com/circleAhn/GraphDrawerAddin/assets/57866999/f463165b-3442-42e5-9e22-bc6e30d08d29">


## Usage

The equation is parsed by `Shunting yard algorithm`, and the supported operator types are following:
* Unary Operator: $\cos(), \sin(), \tan(), \sec(), \csc(), \cot(), \log(), \ln(), abs(), \exp(), e() $
* Binary Operator: $+, -, *, /, \hat{}$  (Power)

with the following graph options settings:
* **가로축 범위(Horizontal axis scope)** `A, B`: Minimum and maximum values of the domain of the coordinate plane, resp.
* **세로축 범위(Vertical axis scope)** `A, B`: Minimum and maximum values of the range of the coordinate plane, resp.
* **정밀도(Precision)** `P`: Number of points when drawing vector graphs
* **확대/축소(Zoom in/out)**: Adjust the size of the graph
* **특이점 주변 정확도(Precision around singular point)**: Improves graph accuracy based on `Newton method`
* **정밀도 동적 조절(Dynamic precision)**: Improves graph accuracy based on `Intermediate value theorem`

GrapX also supported:
* Auto differentiate / drawing differentiate function
* Auto integral / drawing integral function
* Auto tangent line give the point of contact / drawing tangent line
* Solve roots and display
* Solve extreme values and display

GrapX is implemented on `.Net Framework` and `ML.Net` with library `AngouriMath4`.
