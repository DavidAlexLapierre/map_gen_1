from PIL import Image

data = []

file = open("img_data.txt")
lines = file.readlines()
counter = 0

for line in lines:
    line_data = line.split(',')
    data.append(line_data)

width = len(data[0])
height = len(data)

img = Image.new( 'RGB', (width, height), "black") # Create a new black image
pixels = img.load() # Create the pixel map
for i in range(img.size[0]):    # For every pixel:
    for j in range(img.size[1]):
        val = int(float(data[i][j]) * 255)
        pixels[i,j] = (val, val, val) # Set the colour accordingly

img.show()