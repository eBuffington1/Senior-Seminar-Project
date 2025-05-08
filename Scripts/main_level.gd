extends Node2D

@export_subgroup("Boss Phases")
var _phase01 = preload("res://Scenes/BossPhases/phase_01.tscn")
var _phase02 = preload("res://Scenes/BossPhases/phase_02.tscn")
var _phase03 = preload("res://Scenes/BossPhases/phase_03.tscn")

func StartFight(_body: Node2D) -> void:
	$PreFight/PreFight.play("Phases/SetupZone")
	$bossTimelinePlayer.play("bossTimelines/bossSeminar")
	$MusicPlayer.play()

func CleanPreFight() -> void:
	$PreFight.queue_free()

func Phase01() -> void:
	var instance = _phase01.instantiate()
	add_child(instance)

func Phase02() -> void:
	var instance = _phase02.instantiate()
	add_child(instance)

func Phase03() -> void:
	var instance = _phase03.instantiate()
	add_child(instance)
