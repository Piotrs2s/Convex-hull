Convex hull is a convex subset of linear space - the smallest convex set this subset.
In other words, it is a subset of points consisting of the outermost points of a given set.

Program generaters entered number of randomly distributed points and finds convex hull of created set.

Alghoritm at first finds the lowest point (P1) and make auxiliary completely extended point (P2) that makes 180 degrees with first point. 
Then it checks the angle that these two points create with each generated point and finds one that gives the largest angle and adds it to list of convex hull points.
Next point is found in the same way by using first point and point found at first search as P2. Then the proces repeats  in each iteration  for previously found point as P1 
and lately finded point as P2 until new found point is the first one, which means that the hull has been closed. 

Convex hull finds application e.g in computer visualization, patch finding, visual pattern matching or ray tracing
