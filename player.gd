extends CharacterBody2D

@onready var anim: AnimatedSprite2D = $AnimatedSprite2D

const SPEED = 300.0
const DASH_SPEED = 10.0
const DOUBLETAP_DELAY = .15

var doubletap_time = DOUBLETAP_DELAY
var last_keycode = 0
var doubletap = false
var direction_anim = "front"

func _ready() -> void:
	anim.play("idle_front")

func _process(delta):
	doubletap_time -= delta
	
func _input(event):
	if event is InputEventKey and event.is_released():
		if last_keycode == event.keycode and doubletap_time >= 0:
			doubletap=true
			last_keycode = 0
		else :
			last_keycode = event.keycode
	doubletap_time = DOUBLETAP_DELAY
	if event.is_action_pressed("escape"):
		get_tree().GetLevelManager().LoadLevel("pause_menu.tscn",false)
	
	# Debug
	if Input.is_action_just_pressed("save_debug"):
		get_tree().GetSaveManager().Save("user://savegame.save")
		
	if Input.is_action_just_pressed("load_debug"):
		get_tree().GetSaveManager().Load("user://savegame.save")
	
func _physics_process(_delta):
	var direction_horizontal := Input.get_axis("left_axis","right_axis")
	var direction_vertical := Input.get_axis("up_axis","down_axis")
	if direction_horizontal:
		velocity.x = direction_horizontal * SPEED
		if velocity.x < 0 :
			anim.play("walk_left")
			direction_anim = "left"
		else :
			anim.play("walk_right")
			direction_anim = "right"
	else :
		if doubletap :
			velocity.x = move_toward(velocity.x*DASH_SPEED, 0, SPEED)
		else :
			velocity.x = move_toward(velocity.x, 0, SPEED)
			if !direction_vertical :
				anim.play("idle_"+direction_anim)
	if direction_vertical:
		velocity.y = direction_vertical * SPEED
		if anim.animation != "walk_left" && anim.animation != "walk_right" :
			if velocity.y >0 :
				anim.play("walk_front")
				direction_anim = "front"
			else :
				anim.play("walk_back")
				direction_anim = "back"
	else :
		if doubletap :
			velocity.y = move_toward(velocity.y*DASH_SPEED, 0, SPEED)
		else :
			velocity.y = move_toward(velocity.y, 0, SPEED)
			if !direction_horizontal :
				anim.play("idle_"+direction_anim)
	move_and_slide()
	doubletap = false

func save():
	var save_dict = {
		"pos_x" : position.x,
		"pos_y" : position.y,
	}
	return save_dict
