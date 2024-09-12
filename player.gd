extends CharacterBody2D

const SPEED = 300.0

func _physics_process(delta: float) -> void:
	if Input.is_action_just_pressed("left_axis"):
		var direction := Input.get_axis("ui_left","ui_right")
		if direction:
			velocity.x = direction * SPEED
		else:
			velocity.x = move_toward(velocity.x, 0, SPEED)
		move_and_slide()
