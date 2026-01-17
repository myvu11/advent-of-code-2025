
"""
Unittest day4 solution
"""
import unittest
from pathlib import Path
import numpy as np
from src.day4 import count_rolls, read_input, update_count_rolls

BASE_DIR = Path(__file__).resolve().parent.parent

class TestCountRolls(unittest.TestCase):
    """
    Ensure base cases are withhold
    """
    def test_empty_grid(self):
        """
        In case of an empty grid there is no rolls count
        """
        data = np.array([
            [".", "."],
            [".", "."]
        ])
        actual, _ = count_rolls(data)
        expected = 0
        self.assertEqual(actual, expected)

    def test_roll_count_example_input(self):
        """
        Ensure reading from file is correct for the basic test input example
        """

        file_name = BASE_DIR / "Input" / "day4_test.txt"
        data = read_input(file_name)
        expected_data = np.array([
            ['.', '.', '@', '@', '.', '@', '@', '@', '@', '.'],
            ['@', '@', '@', '.', '@', '.', '@', '.', '@', '@'],
            ['@', '@', '@', '@', '@', '.', '@', '.', '@', '@'],
            ['@', '.', '@', '@', '@', '@', '.', '.', '@', '.'],
            ['@', '@', '.', '@', '@', '@', '@', '.', '@', '@'],
            ['.', '@', '@', '@', '@', '@', '@', '@', '.', '@'],
            ['.', '@', '.', '@', '.', '@', '.', '@', '@', '@'],
            ['@', '.', '@', '@', '@', '.', '@', '@', '@', '@'],
            ['.', '@', '@', '@', '@', '@', '@', '@', '@', '.'],
            ['@', '.', '@', '.', '@', '@', '@', '.', '@', '.']
        ])
        np.testing.assert_equal(data, expected_data)

        count, _ = count_rolls(data)
        expected_count = 13
        self.assertEqual(count, expected_count)

    def test_update_stops(self):
        """
        Ensure that the recursive method update_count_rolls does stop when there are no more accessible rolls
        """
        data = np.array([
            ['.', '.'],
            ['.', '.'],
        ])
        count = update_count_rolls(data, 0)
        expected = 0
        self.assertEqual(count, expected)

    def test_update_example(self):
        file_name = BASE_DIR / "Input" / "day4_test.txt"
        data = read_input(file_name)
        count = update_count_rolls(data, 0)
        expected = 43
        self.assertEqual(count, expected)


if __name__ == '__main__':
    unittest.main()
