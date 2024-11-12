import bpy
import os

# Задаем путь к директории с .blend файлами
directory = "."

# Получаем список всех файлов в директории
blend_files = [f for f in os.listdir(os.path.join(directory, "src")) if f.endswith('.blend')]

for blend_file in blend_files:
    blend_path = os.path.join(directory, "src", blend_file)
    
    # Открываем .blend файл
    bpy.ops.wm.open_mainfile(filepath=blend_path)
    
    # Удаляем объект с именем 'Pad', если он существует
    if 'Pad' in bpy.data.objects:
        bpy.data.objects['Pad'].select_set(True)
        bpy.ops.object.delete()
    
    # Сохраняем изменения в исходном .blend файле
    bpy.ops.wm.save_mainfile(filepath=blend_path)
    
    # Экспортируем в FBX с расширенными настройками
    fbx_path = os.path.join(directory, blend_file.replace('.blend', '.fbx'))
    bpy.ops.export_scene.fbx(
        filepath=fbx_path,
        check_existing=True,                  # Перезаписывать существующий FBX файл
        filter_glob="*.fbx",                  # Фильтр для экспорта только в .fbx
        use_selection=False,                  # Экспортировать все объекты, а не только выбранные
        use_active_collection=False,          # Экспортировать объекты только из активной коллекции
        global_scale=1.0,                     # Масштаб при экспорте
        apply_unit_scale=True,                # Применять масштабирование единиц
        apply_scale_options='FBX_SCALE_ALL',  # Опции масштабирования (ALL, FBX_SCALE_NONE)
        use_space_transform=True,             # Использовать преобразование в координаты мирового пространства
        bake_space_transform=True,           # Запекать преобразование координат в анимацию
        object_types={'ARMATURE', 'MESH', 'EMPTY'},    # Типы объектов для экспорта (например, только ARMATURE и MESH)
        use_mesh_modifiers=True,              # Применить модификаторы к мешам
        use_mesh_modifiers_render=False,      # Применять только модификаторы, которые будут видны в рендере
        mesh_smooth_type='OFF',               # Опции сглаживания (OFF, FACE, EDGE, etc.)
        use_subsurf=False,                    # Применить Subdivision Surface модификатор
        use_armature_deform_only=False,       # Экспортировать только деформационные кости
        add_leaf_bones=False,                 # Не добавлять конечные кости к каждому скелету
        primary_bone_axis='Y',                # Главная ось кости (X, Y, Z)
        secondary_bone_axis='X',              # Вторая ось кости (X, Y, Z)
        use_custom_props=False,               # Экспортировать пользовательские свойства
        bake_anim=True,                       # Запекать анимацию
        bake_anim_use_all_bones=True,         # Запекать все кости, даже если они не деформируются
        bake_anim_use_nla_strips=False,       # Не использовать NLA треки
        bake_anim_use_all_actions=False,      # Экспортировать только активные анимации
        bake_anim_force_startend_keying=True, # Включать ключи в начале и конце анимации
        bake_anim_step=1.0,                   # Шаг запекания анимации
        bake_anim_simplify_factor=1.0,        # Степень упрощения анимации
        path_mode='COPY',                     # Режим пути для текстур (AUTO, ABSOLUTE, RELATIVE, etc.)
        embed_textures=True,                 # Встраивать текстуры в FBX файл
        batch_mode='OFF',                     # Режим пакетной обработки (OFF, GROUP, SCENE, COLLECTION)
        use_batch_own_dir=True,               # Создавать отдельную директорию для каждой группы при пакетном экспорте
        axis_forward='-Z',                    # Направление вперед по оси
        axis_up='Y'                           # Направление вверх по оси
    )
    
print("Экспорт завершен.")
