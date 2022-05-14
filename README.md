# GhostBuster
## Solution Overview
To begin with, all grid tiles are assigned the same probability (uniform distribution) **1/8*20** (grid is 8 x 20). The ghost is placed in a random tile using the PlaceGhost() method. Once clicked and with an assigned probability (uncertainty), a tile turns green if the ghost is more than 5 tiles away from it, turns yellow if it is 3 or 4 tiles away from it, turns orange if it is 1 or 2 cells away from it and turns red if it is on it. Based on new evidence (newly clicked tiles), the probabilities on tiles get updated. If a tile is orange, for instance, the probability of green cells that are close by decreases as the ghost is more likely to be 1 or 2 cells away than more than 5 tiles away. Probabilities are normalized using the normalize() function through dividing by the sum of all probabilities. To bust the ghost, the player needs select an already selected tile in, which, they believe, the ghost resides.
- **Demo:** https://www.youtube.com/watch?v=HAQTG9ngwjk
## Probabilistic Inference
Values of sensing are noisy, namely, the distance from the ghost (i.e., color of a tile) is only probable (P(Color/Distance)). Using the latter probability, the color of a tile is defined. However, as stated before, collecting evidence provides hints about the actual location of the ghost. If a tile is red and all tiles around it are green, the probability (P(Ghost/Color)) of the ghost being in that red tile decreases. If the ghost was there indeed, we would get many orange tiles around that red tile all while the probability (P(Ghost/Color)) of that red cell increases. Now, since the evidence is the color of a tile, we can use Bayes’ rule to calculate the probability of the ghost given the color (posterior distribution) as:

P(Ghost/Color) ∝ P(Color/Ghost) * P(Ghost)

However, for better probability values we can use the probability of a color given the actual distance from the ghost. This way, if the probability of the color given the actual distance from the ghost is high, for instance, the probability of the ghost being that far away as indicated by the probability would be accurately as high. Thus, we can use:

P(Ghost/Color) ∝ P(Color/Distance from the ghost) * P(Ghost)

As such, the more evidence (colors) we have the more accurate is the probability of the ghost being in the location indicated by the color. Thereby, inferencing is carried out through updating the belief that the ghost is in a certain location given the probability of tiles’ colors and their actual distance from the ghost.
