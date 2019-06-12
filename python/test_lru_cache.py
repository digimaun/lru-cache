from .lru_cache import LRUCache


def test_lrucache_basic():
    cache = LRUCache(2)

    cache.Put("1", "1")
    cache.Put("2", "2")

    assert "1" == cache.Get("1")   # returns 1

    cache.Put("3", "3")            # evicts key 2
    assert cache.Get("2") is None  # returns None (not found)

    cache.Put("4", "4")            # evicts key 1
    assert cache.Get("1") is None  # returns None (not found)

    assert "3" == cache.Get("3")   # returns 3
    assert "4" == cache.Get("4")   # returns 4

    cache.Put("5", "5")            # evicts key 3
    assert cache.Get("3") is None  # returns None (not found)
    assert "4" == cache.Get("4")   # returns 4
