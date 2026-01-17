"""
Day 4 Solution
"""
from pathlib import Path
import numpy as np

VALID_NEIGHBOUR = "@"
NEIGHBOUR_UPPER_BOUND = 4
NEIGHBOUR_OFFSET = [
    (-1, -1), (-1, 0), (-1, 1),
    (0, -1),           (0, 1),
    (1, -1), (1, 0), (1, 1)
]

def read_input(file_name):
    """Read text file into a 2D NumPy array of characters

    Args:
        file_name (string): path to the input file

    Returns:
        2D NumPy array: containing the file contents
    """
    try:
        with open(file_name, encoding="utf-8") as file:
            data = np.array(
                [list(line.strip()) for line in file if line.strip()],
                dtype=str
            )

    except FileNotFoundError as exc:
        raise FileNotFoundError(f"Input file not found: {file_name}") from exc

    return data

def is_neighbour_roll(adjacent):
    """check whether the adjacent element is a valid value

    Args:
        adjacent (string): the element to be compared with

    Returns:
        boolean: true if the element is a roll
    """
    return adjacent == VALID_NEIGHBOUR


def count_rolls(data):
    """
    Count the number of rolls that can be removed based on neighbour count

    Args:
        data: 2D NumPy array

    Returns:
        Tuple of (count, updated_array)

    """
    removable_count = 0

    new_data = data.copy()

    for i, row in enumerate(data):
        for j, item in enumerate(row):
            count_neighbour = 0

            if item == ".":
                continue

            for nr, nc in NEIGHBOUR_OFFSET:
                r = i + nr
                c = j + nc

                if r == -1 or r == len(row) or c == -1 or c == len(data):
                    continue

                if is_neighbour_roll(data[r][c]):
                    count_neighbour += 1

            if count_neighbour < NEIGHBOUR_UPPER_BOUND:
                removable_count += 1
                new_data[i][j] = "."
            else:
                new_data[i][j] = data[i][j]

    return removable_count, new_data

def update_count_rolls(data, accumulated_count):
    """
    Removing accessible rolls and updating the data after each removement

    Args:
        data (ND.array[string]): the data to remove rolls from
        accumulated_count (int): number of rolls that have been removed

    Returns:
        ND.array[string]: the updated array
        accumulated_count: number of rolls that have been removed
    """
    count_accessible_rolls, new_data = count_rolls(data)
    if(count_accessible_rolls == 0):
        return accumulated_count
    accumulated_count += count_accessible_rolls
    return update_count_rolls(new_data, accumulated_count)

def main():
    """
    Main entry point of the program
    """
    base_dir = Path(__file__).resolve().parent.parent
    file_name = base_dir / "input" / "day4_input.txt"
    data = read_input(file_name)
    [count, _] = count_rolls(data)
    total_count = update_count_rolls(data, 0)
    print("Part 1 total: ", count)
    print("Part 2 total: ", total_count)


if __name__ == "__main__":
    main()
